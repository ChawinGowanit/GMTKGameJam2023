using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCReactionController : MonoBehaviour
{

  [System.Serializable]
  public struct ReactionData
  {
    public string _name;
    public string _reaction;

    public ReactionData(string newName, string newReaction)
    {
      _name = newName;
      _reaction = newReaction;
    }
  }

  [SerializeField] NPCData npc1;
  [SerializeField] NPCData npc2;
  [SerializeField] NPCData npc3;
  [SerializeField] NPCData npc4;
  [SerializeField] NPCData npc5;

  public string getNPCStory(int npc)
  {
    switch (npc)
    {
      case 1:
        return npc1.getStory();
      case 2:
        return npc2.getStory();
      case 3:
        return npc3.getStory();
      case 4:
        return npc4.getStory();
      default:
        return npc5.getStory();
    }
  }

    public string getNPCname(int npc)
  {
    switch (npc)
    {
      case 1:
        return npc1.getName();
      case 2:
        return npc2.getName();
      case 3:
        return npc3.getName();
      case 4:
        return npc4.getName();
      default:
        return npc5.getName();
    }
  }

  public ReactionData getNPCHappyReaction(int npc)
  {
    ReactionData obj;
    switch (npc)
    {
      case 1:
        obj = new ReactionData(npc1.getName(), npc1.getHappyReaction());
        return obj;
      case 2:
        obj = new ReactionData(npc2.getName(), npc2.getHappyReaction());
        return obj;
      case 3:
        obj = new ReactionData(npc3.getName(), npc3.getHappyReaction());
        return obj;
      case 4:
        obj = new ReactionData(npc4.getName(), npc4.getHappyReaction());
        return obj;
      default:
        obj = new ReactionData(npc5.getName(), npc5.getHappyReaction());
        return obj;
    }
  }

  public ReactionData getNPCSadReaction(int npc)
  {
    ReactionData obj;
    switch (npc)
    {
      case 1:
        obj = new ReactionData(npc1.getName(), npc1.getSadReaction());
        return obj;
      case 2:
        obj = new ReactionData(npc2.getName(), npc2.getSadReaction());
        return obj;
      case 3:
        obj = new ReactionData(npc3.getName(), npc3.getSadReaction());
        return obj;
      case 4:
        obj = new ReactionData(npc4.getName(), npc4.getSadReaction());
        return obj;
      default:
        obj = new ReactionData(npc5.getName(), npc5.getSadReaction());
        return obj;
    }
  }
}
