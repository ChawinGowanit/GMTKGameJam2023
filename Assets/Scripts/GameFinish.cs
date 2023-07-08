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

  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Gacha")
    {
      if (tierDict[other.gameObject.GetComponent<Gacha>().getGachaTier()] > tier)
      {
        tier = tierDict[other.gameObject.GetComponent<Gacha>().getGachaTier()];
        tierString = other.gameObject.GetComponent<Gacha>().getGachaTier();
      }
      count++;

      Debug.Log(other.gameObject.GetComponent<Gacha>().getGachaTier());
      //tier = other.gameObject.GetComponent<Gacha>().getGachaTier();
      Destroy(other.gameObject);
    }

    if (FindObjectOfType<GameController>().getCurrentNPCSkill() != "rich")
    {
      if (count == 1)
      {
        count = 0;
        FindObjectOfType<GameController>().RoundEnd(tierString);
        FindObjectOfType<BoxController>().ResetBox();
      }
    }
    else
    {
      if (count == 2)
      {
        count = 0;
        FindObjectOfType<GameController>().RoundEnd(tierString);
        FindObjectOfType<BoxController>().ResetBox();
      }

    }
    tier = 0;
    FindObjectOfType<BoxAnimationController>().RestartBox();
  }
}
