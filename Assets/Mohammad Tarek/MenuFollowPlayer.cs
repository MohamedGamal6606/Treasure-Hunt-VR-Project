using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SettingsMenuToggle : MonoBehaviour
{
    public GameObject settingsCanvas;
    public XRInteractionManager interactionManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }
    }

   public void ToggleMenu()
    {
        
        settingsCanvas.SetActive(!settingsCanvas.activeSelf);

    }
}