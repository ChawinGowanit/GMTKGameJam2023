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
  public void happy()
  {
    npcAnimator.SetTrigger("Happy");
  }
  public void sad()
  {
    npcAnimator.SetTrigger("Sad");
  }
  public void idle()
  {
    npcAnimator.SetTrigger("Idle");
  }
}
