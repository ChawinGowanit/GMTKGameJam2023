using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Gacha")
    {
      Debug.Log(other.gameObject.GetComponent<Gacha>().getGachaTier());
    }
  }
}
