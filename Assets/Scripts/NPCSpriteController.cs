using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpriteController : MonoBehaviour
{
  [SerializeField] Animator npcAnimator;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  public void Happy()
  {
    npcAnimator.SetTrigger("Happy");
  }
  public void Sad()
  {
    npcAnimator.SetTrigger("Sad");
  }
  public void Idle()
  {
    npcAnimator.SetTrigger("Idle");
  }
}
