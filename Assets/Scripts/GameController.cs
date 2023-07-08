using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
  [SerializeField] int currentNPC = 1;
  [SerializeField] List<int> npc = new List<int>();
  [SerializeField] List<string> preferenceTier = new List<string>();
  [SerializeField] List<string> preferenceName = new List<string>();
  [SerializeField] List<string> npcSkills = new List<string>();
  [SerializeField] List<bool> reaction = new List<bool>();
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
      var tiers = new string[] { "silver", "gold", "rainbow" };
      var names = new string[] { "Miyu", "???" };

      string name = names[Random.Range(0, names.Length)];
      string tier = tiers[Random.Range(0, tiers.Length)];
      preferenceName.Add(name);
      preferenceTier.Add(tier);
    }
  }
  public void randomSkill()
  {
    for (int i = 0; i < 3; i++)
    {
      var skills = new string[] { "none", "lucky", "rich" };
      string skill = skills[Random.Range(0, skills.Length)];
      npcSkills.Add(skill);
    }
  }
  public void showNPCPref(int currentNPC)
  {
    //show npc pref /skill
  }
  public void onCloseShowNPC()
  {
    //release ball to start the game
  }
  public void showNPCStory()
  {
    //show NPC story when button is clicked
  }
  public void onFirstBallReach(string prefTier, List<string> prefName)
  {
    //add NPC reaction
  }
  public void showAllReaction()
  {
    //show all NPC reaction
    //finsih game loop
  }
}
