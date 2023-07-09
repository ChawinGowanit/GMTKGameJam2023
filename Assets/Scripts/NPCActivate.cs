using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCActivate : MonoBehaviour
{
  [SerializeField] GameObject npc1;
  [SerializeField] GameObject npc2;

  public void ChangeNPC(int npc)
  {
    npc1.SetActive(false);
    npc2.SetActive(false);
    switch (npc)
    {
      case 1:
        npc1.SetActive(true);
        break;
      case 2:
        npc2.SetActive(true);
        break;
      //   case 3:
      //     return npc3.getStory();
      //   case 4:
      //     return npc4.getStory();
      default:
        return;
    }
  }
}
