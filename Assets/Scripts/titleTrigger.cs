using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleTrigger : MonoBehaviour
{
    public GameObject titlePage;
    public void startScene()
    {
        titlePage.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
