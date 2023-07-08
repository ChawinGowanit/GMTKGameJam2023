using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatController : MonoBehaviour
{

  public TextMeshProUGUI nameObj;
  public TextMeshProUGUI textObj;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  // set NPC name to the component
  public void setName(string newName)
  {
    nameObj.text = newName;
  }

  // set chat text to the component
  public void setText(string newText)
  {
    textObj.text = newText;
  }

}
