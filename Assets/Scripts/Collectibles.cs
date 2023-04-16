using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectibles : MonoBehaviour
{
    GameObject player;
    GameObject floor;
    GameObject screenCover;
    public bool stepper;
    public bool key;
    public bool transporter;

    int keyCollected;
    private GameObject stateManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("doctor");
        floor = GameObject.Find("Separationborder");
        screenCover = GameObject.Find("Canvas/ScreenCover");
        stateManager = GameObject.Find("stateController");
        keyCollected = stateManager.GetComponent<StateManager>().keyCollected;
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "doctor")
        {
            if (stepper == true)
            {
                stateManager.GetComponent<StateManager>().stepperCounter();
                gameObject.SetActive(false);
            }
            else if (key == true)
            {
                stateManager.GetComponent<StateManager>().keyCounter();
                gameObject.SetActive(false);
            }
            else if (transporter == true)
            {
                keyCollected = stateManager.GetComponent<StateManager>().keyCollected;
                if (keyCollected == 1)
                {
                    floor.GetComponent<BoxCollider>().enabled = false;
                    this.GetComponent<MeshCollider>().enabled = false;
                    stateManager.GetComponent<StateManager>().unlockCounter();
                } else if (keyCollected == 2)
                {
                    stateManager.GetComponent<StateManager>().keyDecounter();
                }
            }
        }
    }


}
