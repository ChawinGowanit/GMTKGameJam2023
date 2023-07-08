using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallController : MonoBehaviour
{

  [System.Serializable]
  struct ChatData
  {
    // Image npcImage;
    public string npcName;
    public string chat;

    public ChatData(string newNpcName, string newChat)
    {
      this.npcName = newNpcName;
      this.chat = newChat;
    }
  }

  [SerializeField] List<ChatData> chatDataList = new List<ChatData>();

  // Start is called before the first frame update
  void Start()
  {
    ChatData mockNpc = new ChatData("A", "B");
    chatDataList.Add(mockNpc);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
