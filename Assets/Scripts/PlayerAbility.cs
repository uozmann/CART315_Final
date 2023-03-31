using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerAbility : MonoBehaviour
{
    public int stepperCollected { get; private set; }
    public int keyCollected { get; private set; }
    public bool undergroundUnlocked = false;
    public TextMeshProUGUI numberStepper;
    public GameObject stepperPrefab;
    private GameObject finalDestination;
    private GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<FlyBehaviour>().enabled = false;
        finalDestination = GameObject.Find("SNature_LiliBlossom (1)");
        floor = GameObject.Find("Separationborder");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (stepperCollected > 0)
            {
                Instantiate(stepperPrefab, transform.position + (transform.forward * 2), transform.rotation);
                stepperCollected--;
                numberStepper.text = stepperCollected.ToString();
            }
            else if (stepperCollected <= 0 && undergroundUnlocked)
            {
                gameObject.GetComponent<FlyBehaviour>().enabled = true;
            } 
            if (keyCollected <= 0)
            {
                floor.GetComponent<BoxCollider>().enabled = true;
            }
            
        }
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Debug.Log(keyCollected);
    }
    public void keyDecounter()
    {
        keyCollected--;
    }
    public void unlockCounter()
    {
        undergroundUnlocked = !undergroundUnlocked;
    }
    public void updateUI()
    {
        numberStepper.text = stepperCollected.ToString();
    }
}
