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

  [SerializeField] int currentNPC = 1;
  [SerializeField] List<int> npc = new List<int>();
  [SerializeField] List<string> preferenceTier = new List<string>();
  //[SerializeField] List<string> preferenceName = new List<string>();
  [SerializeField] List<string> npcSkills = new List<string>();
  [SerializeField] List<bool> reaction = new List<bool>();

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
      int r = Random.Range(1, 5);
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
      var tiers = new string[] { "silver", "gold", "rainbow", "lighting Mcqueen", "Nahida" };
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
    npcName.text = npc[currentNPC].ToString();
    prefTier.text = preferenceTier[currentNPC];
    //prefName.text = preferenceName[currentNPC];
    skill.text = npcSkills[currentNPC];
    storyPanel.SetActive(false);
    npcStory.text = this.GetComponent<NPCReactionController>().getNPCStory(npc[currentNPC]);
    infoAnimator.SetTrigger("InfoIn");
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
    infoAnimator.SetTrigger("CharacterOut");
    if (currentNPC < 3)
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
  }

  public string getCurrentNPCSkill()
  {
    return npcSkills[currentNPC];
  }

}
