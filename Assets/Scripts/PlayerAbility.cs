using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerAbility : MonoBehaviour
{
    /*public int stepperCollected;
    public int keyCollected;
    public bool undergroundUnlocked = false;
    public string tempState;
    public string worldState;
    public string playerState;
    public GameObject currentNpc;
    public GameObject previousNpc;*/

    public GameObject stepperPrefab;
    private GameObject stateManager;
 /*   private int stepperCollected;
    private int keyCollected;
    private bool undergroundUnlocked;*/
    private GameObject floor;
    /*   private static bool spawned = false;

       void Awake()
       {
           if (spawned == false)
           {
               spawned = true;
               DontDestroyOnLoad(gameObject);
           }
           else
           {
               DestroyImmediate(gameObject); 
           }
       }*/

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
                Instantiate(stepperPrefab, transform.position + (transform.forward * 2), transform.rotation);
                stateManager.GetComponent<StateManager>().stepperDecounter();
            }
            else if (stateManager.GetComponent<StateManager>().stepperCollected <= 0 && stateManager.GetComponent<StateManager>().undergroundUnlocked)
            {
                gameObject.GetComponent<FlyBehaviour>().enabled = true;
            } 
            if (stateManager.GetComponent<StateManager>().keyCollected <= 0)
            {
                floor.GetComponent<BoxCollider>().enabled = true;
            }
            
        }
    }
/*
    public void stepperCounter()
    {
        stepperCollected++;
    }

    public void stepperDecounter()
    {
        stepperCollected--;
    }

    public void keyCounter()
    {
        keyCollected++;
        if (keyCollected >= 2)
        {
            keyDecounter();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            this.transform.position = new Vector3(-3, 0, -11);
        }
        Debug.Log(keyCollected);
    }
    public void keyDecounter()
    {
        keyCollected = 0;
    }
    public void unlockCounter()
    {
        undergroundUnlocked = !undergroundUnlocked;
    }
    public void updateUI()
    {
    }*/
}
