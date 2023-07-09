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

  public string GetNPCStory(int npc)
  {
    switch (npc)
    {
      case 1:
        return npc1.GetStory();
      case 2:
        return npc2.GetStory();
      case 3:
        return npc3.GetStory();
      case 4:
        return npc4.GetStory();
      default:
        return npc5.GetStory();
    }
  }

  public string GetNPCname(int npc)
  {
    switch (npc)
    {
      case 1:
        return npc1.GetName();
      case 2:
        return npc2.GetName();
      case 3:
        return npc3.GetName();
      case 4:
        return npc4.GetName();
      default:
        return npc5.GetName();
    }
  }

  public ReactionData GetNPCHappyReaction(int npc)
  {
    ReactionData obj;
    switch (npc)
    {
      case 1:
        obj = new ReactionData(npc1.GetName(), npc1.GetHappyReaction());
        return obj;
      case 2:
        obj = new ReactionData(npc2.GetName(), npc2.GetHappyReaction());
        return obj;
      case 3:
        obj = new ReactionData(npc3.GetName(), npc3.GetHappyReaction());
        return obj;
      case 4:
        obj = new ReactionData(npc4.GetName(), npc4.GetHappyReaction());
        return obj;
      default:
        obj = new ReactionData(npc5.GetName(), npc5.GetHappyReaction());
        return obj;
    }
  }

  public ReactionData GetNPCSadReaction(int npc)
  {
    ReactionData obj;
    switch (npc)
    {
      case 1:
        obj = new ReactionData(npc1.GetName(), npc1.GetSadReaction());
        return obj;
      case 2:
        obj = new ReactionData(npc2.GetName(), npc2.GetSadReaction());
        return obj;
      case 3:
        obj = new ReactionData(npc3.GetName(), npc3.GetSadReaction());
        return obj;
      case 4:
        obj = new ReactionData(npc4.GetName(), npc4.GetSadReaction());
        return obj;
      default:
        obj = new ReactionData(npc5.GetName(), npc5.GetSadReaction());
        return obj;
    }
  }
}
