using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatController : MonoBehaviour
{

  public TextMeshProUGUI nameObj;
  public TextMeshProUGUI textObj;

  // set NPC name to the component
  public void SetChatName(string newName)
  {
    nameObj.text = newName;
  }

  // set chat text to the component
  public void SetChatText(string newText)
  {
    textObj.text = newText;
  }

}
