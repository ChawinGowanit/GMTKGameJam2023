using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{

  public GameObject chatPrefab;
  private List<GameObject> chatList = new List<GameObject>();

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void spawnNewChat(string chatName, string chatText)
  {
    GameObject newChat = Instantiate(chatPrefab, transform);
    ChatController newChatController = newChat.GetComponent<ChatController>();

    newChatController.setChatName(chatName);
    newChatController.setChatText(chatText);

    int currentChat = chatList.Count;
    newChat.transform.position = new Vector3(
      newChat.transform.position.x,
      newChat.transform.position.y - (currentChat * 200),
      newChat.transform.position.z);

    chatList.Add(newChat);

  }
}
