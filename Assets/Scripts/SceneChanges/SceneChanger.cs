using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChanger : MonoBehaviour
{
    public void ChangeCutscene()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public void SkipCutscene()
    {
        SceneManager.LoadScene("Sceneworld");
    }

    public void SkipCutSceneNight()
    {
        SceneManager.LoadScene("DarkSceneWorld");
    }
}