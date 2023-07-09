using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyTransition;

public class RestartButton : MonoBehaviour
{
  public TransitionSettings transition;
  public float startDelay;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void OnRestartClicked()
  {
    AudioManager.instance.Play("ButtonPress");
    TransitionManager.Instance().Transition("SampleScene", transition, startDelay);
  }
}
