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

  public string getStory()
  {
    return story;
  }

  public string getName()
  {
    return _name;
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
