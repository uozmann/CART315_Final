using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    GameObject stateManager;

    public int mpMax;
    public int mpCurrent;
    public Image mpMask;
    public TMP_Text keyText;
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
        keyText.text = stateManager.GetComponent<StateManager>().keyCollected.ToString();
    }
}
