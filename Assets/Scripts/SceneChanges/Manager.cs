using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
  public void OnClick()
  {
    SceneManager.LoadScene("Sceneworld");
  }
}
