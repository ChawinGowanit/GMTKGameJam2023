using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
  int count = 0;
  int tier = 0;
  string tierString = "";
  Dictionary<string, int> tierDict = new Dictionary<string, int>();

  void Start()
  {
    tierDict.Add("silver", 1);
    tierDict.Add("gold", 2);
    tierDict.Add("rainbow", 3);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Gacha")
    {
      if (tierDict[other.gameObject.GetComponent<Gacha>().GetGachaTier()] > tier)
      {
        tier = tierDict[other.gameObject.GetComponent<Gacha>().GetGachaTier()];
        tierString = other.gameObject.GetComponent<Gacha>().GetGachaTier();
      }
      count++;
      Destroy(other.gameObject);
    }

    if (FindObjectOfType<GameController>().GetCurrentNPCSkill() == "rich" && count < 2)
    {
      return;
    }
    if (FindObjectOfType<GameController>().GetCurrentNPCSkill() != "rich" && count < 1)
    {
      return;
    }

    count = 0;
    FindObjectOfType<GameController>().RoundEnd(tierString);
    FindObjectOfType<BoxController>().ResetBox();
    FindObjectOfType<BoxAnimationController>().RestartBox();
    tier = 0;

  }
}
