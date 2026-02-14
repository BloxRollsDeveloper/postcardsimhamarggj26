using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
  public void ReturnToMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }

  public void RetryGame()
  {
    SceneManager.LoadScene("Sceneworld");
  }
}
 