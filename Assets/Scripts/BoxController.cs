using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
  [SerializeField] float rotationSpeed = 10f;
  [SerializeField] float shakeMagnitude = 0.1f;

  [SerializeField] Transform[] gachas;
  Vector3 boxInitialPos;
  void Start()
  {
    boxInitialPos = transform.position;
  }

  void Update()
  {
    HandleInnput();
  }

  void HandleInnput()
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
      foreach (var item in gachas)
      {
        Vector2 randomVelocity = Random.insideUnitCircle * 50;
        item.GetComponent<Rigidbody2D>().velocity += randomVelocity;
      }
    }
  }
}
