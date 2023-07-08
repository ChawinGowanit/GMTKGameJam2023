using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCData : MonoBehaviour
{
  public string story;
  public string[] HappyReaction;
  public string[] SadReaction;
  public Image eventImage;
  public string eventText;

  public string getStory()
  {
    return story;
  }

  public string getHappyReaction()
  {
    return HappyReaction[Random.Range(0, HappyReaction.Length)];
  }

  public string getSadReaction()
  {
    return SadReaction[Random.Range(0, SadReaction.Length)];
  }
  public string geteventText()
  {
    return eventText;
  }
}
