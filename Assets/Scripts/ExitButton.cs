using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;

public class ExitButton : MonoBehaviour
{
  public TransitionSettings transition;
  public float startDelay;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  public void OnExitClicked()
  {
    AudioManager.instance.Play("ButtonPress");
    TransitionManager.Instance().Transition("menuScene", transition, startDelay);
  }
}
