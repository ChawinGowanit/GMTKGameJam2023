using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoxController : MonoBehaviour
{
  [Header("Box parameters")]
  [SerializeField] float rotationSpeed = 10f;
  [SerializeField] float shakeMagnitude = 0.1f;
  [SerializeField] BoxCollider2D topCollider;
  [SerializeField] Transform boxInitiaalTransform;
  [SerializeField] Transform spinningObstacle;
  [SerializeField] float obstacleRotationSpeed = 200f;
  [SerializeField] GameObject obstacles;

  [Header("Gacha parameters")]
  [SerializeField] GameObject gachaSilver;
  [SerializeField] GameObject gachaGold;
  [SerializeField] GameObject gachaRainbow;
  [SerializeField] GameObject[] gachas;
  [SerializeField] GameObject gachasParent;
  [SerializeField] Transform[] spawnPoints;

  Vector3 boxInitialPos;
  bool canControl = false;

  void Start()
  {
    boxInitialPos = transform.position;
    topCollider.enabled = false;
    //GenerateGacha();
  }

  void Update()
  {
    HandleInnput();
    Spin();
  }

  void HandleInnput()
  {

    if (!canControl)
    {
      return;
    }

    if (Input.GetKey(KeyCode.A))
    {
      transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    else if (Input.GetKey(KeyCode.D))
    {
      transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }

    if (Input.GetKeyDown(KeyCode.Space))
    {
      Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;

      Rigidbody2D[] childRigidbodies = gachasParent.GetComponentsInChildren<Rigidbody2D>();
      foreach (var item in childRigidbodies)
      {
        Vector2 randomVelocity = Random.insideUnitCircle * 15;
        item.velocity += randomVelocity;
      }
    }

  }

  IEnumerator StartGame()
  {
    yield return new WaitForSecondsRealtime(2.5f);
    SetupGachaPos();
    canControl = true;
    topCollider.enabled = true;
    obstacles.SetActive(true);
  }

  void SetupGachaPos()
  {
    ShuffleArray(spawnPoints);
    ShuffleArray(gachas);

    int numObjects = Mathf.Min(spawnPoints.Length, gachas.Length);
    for (int i = 0; i < numObjects; i++)
    {
      var spawnGacha = Instantiate(gachas[i], spawnPoints[i].position, spawnPoints[i].rotation);
      spawnGacha.transform.parent = gachasParent.transform;
    }
  }

  void ShuffleArray<T>(T[] array)
  {
    int n = array.Length;
    while (n > 1)
    {
      int k = Random.Range(0, n);
      n--;
      (array[k], array[n]) = (array[n], array[k]);
    }
  }

  public void GenerateGacha(string skill, string tier)
  {
    AddItem(gachaRainbow);
    AddItem(gachaGold);
    AddItem(gachaSilver);
    if (skill == "lucky")
    {
      AddItem(gachaRainbow);
      AddItem(gachaRainbow);
    }
    else if (skill == "salty")
    {
      AddItem(gachaSilver);
      AddItem(gachaSilver);
    }
    else
    {
      for (int i = 0; i < 2; i++)
      {
        int randomNum = Random.Range(0, 3);
        AddItem(gachas[randomNum]);
      }
    }
    FindObjectOfType<BoxAnimationController>().PressedBox();
    StartCoroutine("StartGame");
  }

  void AddItem(GameObject newItem)
  {
    System.Array.Resize(ref gachas, gachas.Length + 1);
    gachas[gachas.Length - 1] = newItem;
  }

  public void ResetBox()
  {
    transform.rotation = Quaternion.Euler(0, 0, 0);
    canControl = false;
    topCollider.enabled = false;
    gachas = new GameObject[0];
    foreach (Transform child in gachasParent.transform)
    {
      Destroy(child.gameObject);
    }
    obstacles.SetActive(false);
  }

  void Spin()
  {
    if (canControl)
    {
      spinningObstacle.Rotate(Vector3.forward, obstacleRotationSpeed * Time.deltaTime);
    }
  }
}
