using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceManager : MonoBehaviour
{
    public int storyCount = 0;
    public GameObject currentNpc;
    public GameObject previousNpc;
    public string currentTextChoice1;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentTextChoice1 = "default";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentNpc.name);
        if (currentNpc != null)
        {
            if (previousNpc == null)
            {
                currentTextChoice1 = "Bananas";
                previousNpc = currentNpc;
            } else if (currentNpc.name != previousNpc.name)
            {
                currentTextChoice1 = currentNpc.name;
                previousNpc = currentNpc;
            }
        }

    }
}
