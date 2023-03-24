using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviours : MonoBehaviour
{
    GameObject cam1; //player cam
    GameObject cam2;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("doctor");
        cam1 = GameObject.Find("Camera_player");
        cam2 = GameObject.Find("Camera_dialogue");
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDialogue()
    {
        cam2.transform.position = player.transform.position + player.transform.right * 4 + player.transform.forward * 2 + player.transform.up * 2;
        cam1.SetActive(false);
        cam2.SetActive(true);
        cam2.transform.LookAt(player.transform);
        player.GetComponent<MoveBehaviour>().walkSpeed = 0;
        player.GetComponent<MoveBehaviour>().runSpeed = 0;
        player.GetComponent<MoveBehaviour>().sprintSpeed = 0;
    }

    public void OffDialogue()
    {
        cam2.SetActive(false);
        cam1.SetActive(true);
        player.GetComponent<MoveBehaviour>().walkSpeed = 1.0f;
        player.GetComponent<MoveBehaviour>().runSpeed = 1.0f;
        player.GetComponent<MoveBehaviour>().sprintSpeed = 2.0f;
    }
}
