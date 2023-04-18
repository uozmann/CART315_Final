using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerAbility : MonoBehaviour
{
    public GameObject stepperPrefab;
    private GameObject stateManager;
    private GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<FlyBehaviour>().enabled = false;
        floor = GameObject.Find("Separationborder");
        stateManager = GameObject.Find("stateController");   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (stateManager.GetComponent<StateManager>().stepperCollected > 0)
            {
                Instantiate(stepperPrefab, transform.position, transform.rotation);
                stateManager.GetComponent<StateManager>().stepperDecounter();
            }
            if (stateManager.GetComponent<StateManager>().keyCollected >= 2)
            {
                gameObject.GetComponent<FlyBehaviour>().enabled = true;
            } 
            if (stateManager.GetComponent<StateManager>().undergroundUnlocked)
            {
                floor.GetComponent<BoxCollider>().enabled = true;
                gameObject.GetComponent<FlyBehaviour>().enabled = true;
            } else if (stateManager.GetComponent<StateManager>().undergroundUnlocked == false)
            {
                gameObject.GetComponent<FlyBehaviour>().enabled = false;
            }

        }
    }
}
