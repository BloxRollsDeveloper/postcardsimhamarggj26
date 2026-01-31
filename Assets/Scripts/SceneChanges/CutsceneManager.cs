using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public List<GameObject> panels = new List<GameObject>();
    public float panelDuration = 4f;

    private int currentPanelIndex = 0;

    void Start()
    {
        ShowOnlyCurrentPanel();
        // StartCoroutine(PlayCutscene());
    }

    void ShowOnlyCurrentPanel()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(i == currentPanelIndex);
        }
    }
    
}
