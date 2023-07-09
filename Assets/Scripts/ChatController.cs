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
    switch (newName)
    {
      case "Mascot": imgPath = "npc1icon"; break;
      case "Wimpy Kid": imgPath = "npc2icon"; break;
      case "Witch": imgPath = "npc3icon"; break;
      case "Normie Girl": imgPath = "npc4icon"; break;
      default: imgPath = "npc5icon"; break;
    }
    npcImage.sprite = Resources.Load<Sprite>(imgPath);
  }

  // set chat text to the component
  public void SetChatText(string newText)
  {

    if (nameObj.text == "Witch" && newText[0] == 'r')
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

}
