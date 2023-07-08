using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
  [SerializeField] string tier;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public string getGachaTier()
  {
    return tier;
  }
}
