using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ChatController : MonoBehaviour
{

  public TMP_FontAsset runic;
  public TMP_FontAsset normal;
  public TextMeshProUGUI nameObj;
  public TextMeshProUGUI textObj;
  public Image npcImage;
  Sprite npcicon;
  // set NPC name to the component
  public void SetChatName(string newName)
  {
    nameObj.text = newName;
  }

  public void SetChatImage(string newName)
  {
    string imgPath = "";
    if (newName == "Mascot")
    {
      imgPath = "npc1icon";
    }
    else if (newName == "Wimpy Kid")
    {
      imgPath = "npc2icon";
    }
    else if (newName == "Witch")
    {
      imgPath = "npc3icon";
    }
    else if (newName == "Normie Girl")
    {
      imgPath = "npc4icon";
    }
    else if (newName == "Paddle Pop")
    {
      imgPath = "npc5icon";
    }
    npcImage.sprite = Resources.Load<Sprite>(imgPath);
  }

  // set chat text to the component
  public void SetChatText(string newText)
  {
    if (nameObj.text == "Witch")
    {
      if (newText[0] == 'r')
      {
        textObj.font = runic;
        textObj.text = newText.Substring(1);
      }
      else
      {
        textObj.font = normal;
        textObj.text = newText;
      }

    }
    else
    {
      textObj.font = normal;
      textObj.text = newText;
    }
  }

}
