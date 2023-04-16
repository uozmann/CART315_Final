using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeAnimation : MonoBehaviour
{
    private Animator eyeAnimator;
    GameObject screenCover;
    private GameObject stateManager;

    public GameObject ObjectToAppear;
    public GameObject UIToAppear;
    public bool AppearObject = false;

    // Start is called before the first frame update
    void Start()
    {
        screenCover = GameObject.Find("ScreenCover");
        eyeAnimator = screenCover.GetComponent<Animator>();
        stateManager = GameObject.Find("stateController");
    }

    // Update is called once per frame
    void Update()
    {
        if(AppearObject == true)
        {
            ObjectToAppear.SetActive(AppearObject);
            UIToAppear.SetActive(AppearObject);
        }
    }
    public void BlackOut()
    {
         if (stateManager.GetComponent<StateManager>().currentNpc.name == "assistant01")
        {
            eyeAnimator.SetTrigger("TrigBlackOut");
        }
    }
}
