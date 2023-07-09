using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

  enum GameState
  {
    START,
    NPC_ENTER,
    PLAY,
    NPC_LEAVE,
    OVERALL
  }

  [SerializeField] int currentNPC = 0;
  [SerializeField] List<int> npc = new List<int>();
  [SerializeField] List<string> preferenceTier = new List<string>();
  //[SerializeField] List<string> preferenceName = new List<string>();
  [SerializeField] List<string> npcSkills = new List<string>();
  [SerializeField] List<NPCReactionController.ReactionData> reactionList = new List<NPCReactionController.ReactionData>();
  [SerializeField] GameObject panel;

  [Header("Current NPC info")]
  [SerializeField] GameObject npcInfoPanel;
  [SerializeField] TextMeshProUGUI npcName;
  //[SerializeField] TextMeshProUGUI prefName;
  [SerializeField] TextMeshProUGUI prefTier;
  [SerializeField] TextMeshProUGUI skill;
  [SerializeField] GameObject storyPanel;
  [SerializeField] TextMeshProUGUI npcStory;
  [SerializeField] Animator infoAnimator;
  [SerializeField] Button closeBtn;
  [SerializeField] Image npcImage;

  Sprite npc1icon;
  Sprite npc2icon;
  Sprite npc3icon;
  Sprite npc4icon;
  Sprite npc5icon;


  void Start()
  {
    loadSprite();
    // NOTE - init NPC ,pref ,and skill
    RandomGameloop();
    // NOTE - start first NPC
    ChangeNPC();
    ShowNPCPref(currentNPC);
  }
  public void loadSprite()
  {
    npc1icon = Resources.Load<Sprite>("npc1icon");
    npc2icon = Resources.Load<Sprite>("npc2icon");
    npc3icon = Resources.Load<Sprite>("npc3icon");
    npc4icon = Resources.Load<Sprite>("npc4icon");
    npc5icon = Resources.Load<Sprite>("npc5icon");
  }

  public void RandomGameloop()
  {
    RandomNPC();
    RandomPref();
    RandomSkill();
  }

  public void RandomNPC()
  {
    while (npc.Count < 3)
    {
      bool isIn = false;
      int r = Random.Range(1, 6);
      foreach (var item in npc)
      {
        if (r == item)
        {
          isIn = true;
        }
      }
      if (!isIn)
      {
        npc.Add(r);
      }
    }
  }

  public void RandomPref()
  {
    for (int i = 0; i < 3; i++)
    {
      var tiers = new string[] { "silver", "gold", "rainbow" };
      string tier = tiers[Random.Range(0, tiers.Length)];
      preferenceTier.Add(tier);
    }
  }

  public void RandomSkill()
  {
    for (int i = 0; i < 3; i++)
    {
      var skills = new string[] { "none", "lucky", "rich", "salty" };
      string skill = skills[Random.Range(0, skills.Length)];
      npcSkills.Add(skill);
    }
  }

  public void ShowNPCPref(int currentNPC)
  {
    // NOTE - show npc pref /skill
    closeBtn.enabled = true;
    npcInfoPanel.SetActive(true);
    npcName.text = "Name: " + FindObjectOfType<NPCReactionController>().GetNPCname(npc[currentNPC]);
    prefTier.text = "Want: " + preferenceTier[currentNPC];
    skill.text = "Skill: " + npcSkills[currentNPC];
    storyPanel.SetActive(false);
    npcStory.text = this.GetComponent<NPCReactionController>().GetNPCStory(npc[currentNPC]);
    setNpcImage(npc[currentNPC]);
    infoAnimator.SetTrigger("InfoIn");
    // NOTE - npc sprite
  }

  public void setNpcImage(int npc)
  {
    switch (npc)
    {
      case 1:
        npcImage.sprite = npc1icon;
        return;
      case 2:
        npcImage.sprite = npc2icon;
        return;
      case 3:
        npcImage.sprite = npc3icon;
        return;
      case 4:
        npcImage.sprite = npc4icon;
        return;
      case 5:
        npcImage.sprite = npc5icon;
        return;
      default:
        return;
    }
  }

  public void OnCloseShowNPC()
  {
    infoAnimator.SetTrigger("InfoOut");
    AudioManager.instance.Play("ButtonPress");
    FindObjectOfType<BoxController>().GenerateGacha(npcSkills[currentNPC], preferenceTier[currentNPC]);
    closeBtn.enabled = false;
  }

  public void ToggleNPCStory()
  {
    storyPanel.SetActive(!storyPanel.activeInHierarchy);
    AudioManager.instance.Play("ButtonPress");
  }

  public void RoundEnd(string tier)
  {
    NPCReactionController.ReactionData reaction;
    if (tier == preferenceTier[currentNPC])
    {
      reaction = FindObjectOfType<NPCReactionController>().GetNPCHappyReaction(npc[currentNPC]);
      FindObjectOfType<NPCSpriteController>().Happy();
    }
    else
    {
      reaction = FindObjectOfType<NPCReactionController>().GetNPCSadReaction(npc[currentNPC]);
      FindObjectOfType<NPCSpriteController>().Sad();
    }
    reactionList.Add(reaction);

    infoAnimator.SetTrigger("CharacterOut");
    if (currentNPC < 2)
    {
      currentNPC++;
      ShowNPCPref(currentNPC);
    }
    else
    {
      ShowAllReaction();
    }

  }

  // show all NPC reaction
  // finsih game loop
  public void ShowAllReaction()
  {

    infoAnimator.SetTrigger("PhoneIn");
    foreach (var reaction in reactionList)
    {
      panel.GetComponent<PanelController>().SpawnNewChat(reaction._name, reaction._reaction);
    }

  }

  public string GetCurrentNPCSkill()
  {
    return npcSkills[currentNPC];
  }

  public void ChangeNPC()
  {
    //Debug.Log(currentNPC);
    //Debug.Log(npc[currentNPC]);
    FindObjectOfType<NPCActivate>().ChangeNPC(npc[currentNPC]);
  }

}
