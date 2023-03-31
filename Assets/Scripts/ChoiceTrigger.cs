using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceTrigger : MonoBehaviour
{
    public GameObject ChoiceManager;
    public TMP_Text choiceName;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(variableControl);
        choiceName.text = ChoiceManager.GetComponent<ChoiceManager>().currentTextChoice1;
    }

    // Update is called once per frame
    void Update()
    {
        choiceName.text = ChoiceManager.GetComponent<ChoiceManager>().currentTextChoice1;
    }

    void variableControl()
    {
        ChoiceManager.GetComponent<ChoiceManager>().storyCount += 1;
        /*Debug.Log("Clicked");*/
    }
}
