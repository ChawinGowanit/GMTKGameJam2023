using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
  [SerializeField] string tier;

  public string GetGachaTier()
  {
    return tier;
  }
}
