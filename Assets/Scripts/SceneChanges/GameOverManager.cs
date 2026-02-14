using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public InputAction mainMenuButton;

    private void OnEnable()
    {
        mainMenuButton.Enable();
    }

    private void OnDisable()
    {
        mainMenuButton.Disable();
    }

    void Update()
    {
        if (mainMenuButton.WasPressedThisFrame())
        {
            LoadMainMenu();
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}