using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAnimationController : MonoBehaviour
{
  Animator myAnimator;
  void Start()
  {
    myAnimator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
  }

  public void PressedBox()
  {
    myAnimator.Play("Box_pressed");
  }

  public void RestartBox()
  {
    myAnimator.Play("Box_idle");
  }

}
