using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        isActive = true;
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        TextTransition();
    }

    public void DisplayNextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseOutExpo();
            isActive = false;
            Debug.Log("End of conversation ");
            FindObjectOfType<CameraBehaviours>().OffDialogue();
            FindObjectOfType<EyeAnimation>().BlackOut();
        }
    }
    void TextTransition()
    {
        /*LeanTween.color(messageText.GetComponent<RectTransform>, 0, 0);
        LeanTween.color(messageText.GetComponent<RectTransform>, 1, 0.5f);*/
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            DisplayNextMessage();
        }
    }
}
