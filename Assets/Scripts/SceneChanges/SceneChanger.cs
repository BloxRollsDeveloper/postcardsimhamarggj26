using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChanger : MonoBehaviour
{
    public InputAction DayModeButton;
    public InputAction NightModeButton;
    
    private void OnEnable()
    {
        DayModeButton.Enable();
        NightModeButton.Enable();
    }

    private void OnDisable()
    {
        DayModeButton.Disable();
        NightModeButton.Disable();
    }

    public void Update()
    {
        if (DayModeButton.WasPressedThisFrame())
        {
            SceneManager.LoadScene("Sceneworld");
        }
        if (NightModeButton.WasPressedThisFrame())
        {
            SceneManager.LoadScene("DarkSceneWorld");
        }
    }
}