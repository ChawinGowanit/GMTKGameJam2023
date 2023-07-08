using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCReactionController : MonoBehaviour
{
  [SerializeField] NPCData npc1;
  [SerializeField] NPCData npc2;
  [SerializeField] NPCData npc3;
  [SerializeField] NPCData npc4;
  [SerializeField] NPCData npc5;

  public string getNPCStory(int npc)
  {
    if (npc == 1)
    {
      return npc1.getStory();
    }
    else if (npc == 2)
    {
      return npc2.getStory();
    }
    else if (npc == 3)
    {
      return npc3.getStory();
    }
    else if (npc == 4)
    {
      return npc4.getStory();
    }
    else
    {
      return npc5.getStory();
    }
  }
}
