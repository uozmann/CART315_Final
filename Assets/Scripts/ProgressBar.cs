using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    GameObject stateManager;

    public int mpMax;
    public int mpCurrent;
    public Image mpMask;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("stateController");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        mpCurrent = stateManager.GetComponent<StateManager>().stepperCollected;
        float fillAmount = (float)mpCurrent / (float)mpMax;
        mpMask.fillAmount = fillAmount;
    }
}
