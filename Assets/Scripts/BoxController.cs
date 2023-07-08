using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
  [Header("Box parameters")]
  [SerializeField] float rotationSpeed = 10f;
  [SerializeField] float shakeMagnitude = 0.1f;
  [SerializeField] BoxCollider2D topCollider;

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
    GenerateGacha();
    SetupGachaPos();
    StartCoroutine("StartGame");
  }

  void Update()
  {
    HandleInnput();
  }

  void HandleInnput()
  {
    if (canControl)
    {
      if (Input.GetKey(KeyCode.A))
      {
        Debug.Log("Rotate Left");
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
      }
      else if (Input.GetKey(KeyCode.D))
      {
        Debug.Log("Rotate Right");
        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
      }

      if (Input.GetKeyDown(KeyCode.Space))
      {
        Debug.Log("Shake!!!");
        Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;

        //Shake box
        //transform.position = boxInitialPos + randomOffset;

        //Shake ball
        Rigidbody2D[] childRigidbodies = gachasParent.GetComponentsInChildren<Rigidbody2D>();
        foreach (var item in childRigidbodies)
        {
          Vector2 randomVelocity = Random.insideUnitCircle * 30;
          item.velocity += randomVelocity;
        }
      }
    }
  }

  IEnumerator StartGame()
  {
    yield return new WaitForSecondsRealtime(1);
    canControl = true;
    topCollider.enabled = true;
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
      T temp = array[n];
      array[n] = array[k];
      array[k] = temp;
    }
  }

  public void GenerateGacha()
  {
    AddItem(gachaRainbow);
    AddItem(gachaGold);
    AddItem(gachaSilver);
  }

  void AddItem(GameObject newItem)
  {
    System.Array.Resize(ref gachas, gachas.Length + 1);

    gachas[gachas.Length - 1] = newItem;
  }

}
