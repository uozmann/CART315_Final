using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    private static bool spawned = false;

    public int stepperCollected;
    public int keyCollected;
    public bool undergroundUnlocked = false;
    public string tempState;
    public string worldState;
    public string playerState;
    public GameObject currentNpc;
    public GameObject previousNpc;
    public GameObject assistantToInstall;

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
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


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
            nextScene();
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

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void firstScene()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
