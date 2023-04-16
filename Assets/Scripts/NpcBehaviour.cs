using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehaviour : MonoBehaviour
{
    public DialogueTrigger trigger;
    // For distance
    public Transform player;
    public bool repeatMessage = false;
    public bool lookAtPlayer = false;
    bool touchedNpc = false;
    private GameObject stateManager;

    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("stateController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (player)
        {
            float dist = Vector3.Distance(player.position, transform.position);
            if (dist < 2 && touchedNpc == false)
            {
                trigger.StartDialogue();               
                touchedNpc = true;
                stateManager.GetComponent<StateManager>().currentNpc = this.gameObject;
                Debug.Log("touched");
            }
            else if (dist > 2 && touchedNpc == true && repeatMessage == true)
            {
                touchedNpc = false;
            }
            else if (dist > 2 && dist < 6 && lookAtPlayer == true)
            {
                this.transform.LookAt(player);
            }
        }
    }
}
