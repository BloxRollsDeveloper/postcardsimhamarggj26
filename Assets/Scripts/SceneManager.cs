using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
public void StartGame()
    {
        SceneManagement.LoadScene("SampleScene");
        Debug.Log("Entering Main Scene...");
    }
}
