using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EasyTransition;
public class Menu : MonoBehaviour
{
  [SerializeField] GameObject[] gachas;
  [SerializeField] Transform[] spawnPoints;
  [SerializeField] Animator buttonAnimator;
  public TransitionSettings transition;
  public float startDelay;


  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine("gachaSpawn");
  }

  // Update is called once per frame
  void Update()
  {

  }
  IEnumerator gachaSpawn()
  {
    yield return new WaitForSeconds(3);
    spawn();
  }
  void spawn()
  {
    int randomGacha = Random.Range(0, gachas.Length);
    int randomNum = Random.Range(0, spawnPoints.Length);
    var spawnGacha = Instantiate(gachas[randomGacha], spawnPoints[randomNum].position, Quaternion.identity);
    Vector2 randomVelocity = Random.insideUnitCircle * 5;
    spawnGacha.GetComponent<Rigidbody2D>().velocity += randomVelocity;
    StartCoroutine("gachaSpawn");
  }

  public void playClicked()
  {
    buttonAnimator.SetTrigger("play");
  }
  public void exitClicked()
  {
    Application.Quit();
  }
  public void playGame(string sceneName)
  {
    TransitionManager.Instance().Transition(sceneName, transition, startDelay);
  }
  public void GachaClick()
  {
    AudioManager.instance.Play("GachaClick");
  }
}
