using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCData : MonoBehaviour
{
  [SerializeField] string _name;
  [SerializeField] string story;
  [SerializeField] string[] HappyReaction;
  [SerializeField] string[] SadReaction;
  [SerializeField] Image eventImage;
  [SerializeField] string eventText;

  public string GetStory()
  {
    return story;
  }

  public string GetName()
  {
    return _name;
  }
  public string GetHappyReaction()
  {
    return HappyReaction[Random.Range(0, HappyReaction.Length)];
  }

  public string GetSadReaction()
  {
    return SadReaction[Random.Range(0, SadReaction.Length)];
  }
  public string GetEventText()
  {
    return eventText;
  }
}
