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

  void Start()
  {
    // init NPC ,pref ,and skill
    randomGameloop();
    // start first NPC
    changeNPC();
    showNPCPref(currentNPC);
  }
  void Update()
  {
  }
  public void randomGameloop()
  {
    randomNPC();
    randomPref();
    randomSkill();
  }
  public void randomNPC()
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
  public void randomPref()
  {
    for (int i = 0; i < 3; i++)
    {
      var tiers = new string[] { "silver", "gold", "rainbow" };
      //var names = new string[] { "Miyu", "???" };

      //string name = names[Random.Range(0, names.Length)];
      string tier = tiers[Random.Range(0, tiers.Length)];
      //preferenceName.Add(name);
      preferenceTier.Add(tier);
    }
  }
  public void randomSkill()
  {
    for (int i = 0; i < 3; i++)
    {
      var skills = new string[] { "none", "lucky", "rich", "salty" };
      string skill = skills[Random.Range(0, skills.Length)];
      npcSkills.Add(skill);
    }
  }
  public void showNPCPref(int currentNPC)
  {
    //show npc pref /skill
    closeBtn.enabled = true;
    npcInfoPanel.SetActive(true);
    npcName.text = "Name: " + FindObjectOfType<NPCReactionController>().getNPCname(npc[currentNPC]);
    prefTier.text = "Want: " + preferenceTier[currentNPC];
    //prefName.text = preferenceName[currentNPC];
    skill.text = "Skill: " + npcSkills[currentNPC];
    storyPanel.SetActive(false);
    npcStory.text = this.GetComponent<NPCReactionController>().getNPCStory(npc[currentNPC]);
    infoAnimator.SetTrigger("InfoIn");
    //npc sprite
  }
  public void onCloseShowNPC()
  {
    infoAnimator.SetTrigger("InfoOut");
    FindObjectOfType<BoxController>().GenerateGacha(npcSkills[currentNPC], preferenceTier[currentNPC]);
    closeBtn.enabled = false;

    //machine.start()

  }
  public void toggleNPCStory()
  {
    if (storyPanel.activeInHierarchy)
    {
      storyPanel.SetActive(false);
    }
    else
    {
      storyPanel.SetActive(true);
    }
  }
  public void RoundEnd(string tier)
  {
    NPCReactionController.ReactionData reaction;
    Debug.Log("Tier");
    Debug.Log(tier);
    Debug.Log("pref");
    Debug.Log(preferenceTier[currentNPC]);
    if (tier == preferenceTier[currentNPC])
    {
      reaction = FindObjectOfType<NPCReactionController>().getNPCHappyReaction(npc[currentNPC]);
      FindObjectOfType<NPCSpriteController>().happy();
    }
    else
    {
      reaction = FindObjectOfType<NPCReactionController>().getNPCSadReaction(npc[currentNPC]);
      FindObjectOfType<NPCSpriteController>().sad();
    }
    reactionList.Add(reaction);

    infoAnimator.SetTrigger("CharacterOut");
    if (currentNPC < 2)
    {
      currentNPC++;
      showNPCPref(currentNPC);
    }
    else
    {
      showAllReaction();
    }

  }
  public void showAllReaction()
  {
    //show all NPC reaction
    //finsih game loop
    infoAnimator.SetTrigger("PhoneIn");
    foreach (var reaction in reactionList)
    {
      panel.GetComponent<PanelController>().spawnNewChat(reaction._name, reaction._reaction);
    }

  }

  public string getCurrentNPCSkill()
  {
    return npcSkills[currentNPC];
  }
  public void changeNPC()
  {
    FindObjectOfType<NPCActivate>().changeNPC(npc[currentNPC]);
  }

}
