using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCActivate : MonoBehaviour
{
  [SerializeField] GameObject npc1;
  [SerializeField] GameObject npc2;
  [SerializeField] GameObject npc3;
  [SerializeField] GameObject npc4;
  [SerializeField] GameObject npc5;


  public void ChangeNPC(int npc)
  {
    npc1.SetActive(false);
    npc2.SetActive(false);
    npc3.SetActive(false);
    npc4.SetActive(false);
    npc5.SetActive(false);
    switch (npc)
    {
      case 1:
        npc1.SetActive(true);
        break;
      case 2:
        npc2.SetActive(true);
        break;
      case 3:
        npc3.SetActive(true);
        break;
      case 4:
        npc4.SetActive(true);
        break;
      case 5:
        npc5.SetActive(true);
        break;
      default:
        return;
    }
  }
}
