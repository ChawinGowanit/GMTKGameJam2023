using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{

  [SerializeField] ParticleSystem gacahInParticle;
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
    GetComponent<BoxCollider2D>().enabled = false;
    if (other.gameObject.tag != "Gacha")
    {
      goto exited;
    }
    AudioManager.instance.Play("GachaGet");
    if (!gacahInParticle.isPlaying)
    {
      gacahInParticle.Play();
    }
    if (tierDict[other.gameObject.GetComponent<Gacha>().GetGachaTier()] > tier)
    {
      tier = tierDict[other.gameObject.GetComponent<Gacha>().GetGachaTier()];
      tierString = other.gameObject.GetComponent<Gacha>().GetGachaTier();
    }
    count++;
    Destroy(other.gameObject);

    if (FindObjectOfType<GameController>().GetCurrentNPCSkill() == "rich" && count < 2)
    {
      goto exited;
    }
    if (FindObjectOfType<GameController>().GetCurrentNPCSkill() != "rich" && count < 1)
    {
      goto exited;
    }

    count = 0;
    tier = 0;
    gacahInParticle.transform.position = other.transform.position;
    FindObjectOfType<GameController>().RoundEnd(tierString);
    FindObjectOfType<BoxController>().ResetBox();
    FindObjectOfType<BoxAnimationController>().RestartBox();
    exited:
      GetComponent<BoxCollider2D>().enabled = true;
  }
}
