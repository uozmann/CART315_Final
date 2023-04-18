using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StationChoice : MonoBehaviour
{
    private GameObject assistantToInstall;
    public GameObject stationGateBtns;
    private GameObject stateManager;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("stateController");
        assistantToInstall = stateManager.GetComponent<StateManager>().assistantToInstall;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onOpenGate()
    {
        assistantToInstall = stateManager.GetComponent<StateManager>().assistantToInstall;
        assistantToInstall.GetComponent<MeshRenderer>().enabled = true;
        assistantToInstall.GetComponent<NpcBehaviour>().enabled = true;
        FindObjectOfType<CameraBehaviours>().OffGateButton();
        stationGateBtns.SetActive(false);
    }

    public void onDecline()
    {
        FindObjectOfType<CameraBehaviours>().OffGateButton();
        stationGateBtns.SetActive(false);
    }
}
