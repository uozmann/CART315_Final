using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    GameObject player;
    GameObject floor;
    GameObject screenCover;
    public bool stepper;
    public bool key;
    public bool transporter;

    int keyCollected;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("doctor");
        floor = GameObject.Find("Separationborder");
        screenCover = GameObject.Find("Canvas/ScreenCover");
        keyCollected = player.GetComponent<PlayerAbility>().keyCollected;
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "doctor")
        {
            if (stepper == true)
            {
                player.GetComponent<PlayerAbility>().stepperCounter();
                gameObject.SetActive(false);
            }
            else if (key == true)
            {
                player.GetComponent<PlayerAbility>().keyCounter();
                gameObject.SetActive(false);
            }
            else if (transporter == true)
            {
                keyCollected = player.GetComponent<PlayerAbility>().keyCollected;
                if (keyCollected >= 1)
                {
                    floor.GetComponent<BoxCollider>().enabled = false;
                    this.GetComponent<MeshCollider>().enabled = false;
                    /*screenCover.GetComponent<Animation>().Play("blackOut");*/
                    player.GetComponent<PlayerAbility>().keyDecounter();
                    player.GetComponent<PlayerAbility>().unlockCounter();
                }
            }
            player.GetComponent<PlayerAbility>().updateUI();
        }
    }


}
