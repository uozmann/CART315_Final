using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // For messages
    public Message[] messages;
    public Actor[] actors;

    // For distance triggers
    public Transform player;
    public GameObject dialogBox;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
        FindObjectOfType<CameraBehaviours>().OnDialogue();
        Debug.Log("StartDdialogue");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;

}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}