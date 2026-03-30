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

    void ToggleMenu()
    {
        bool isActive = !settingsCanvas.activeSelf;
        settingsCanvas.SetActive(isActive);

        // Optional: Disable interaction when menu is open
        if (interactionManager != null)
        {
            interactionManager.enabled = !isActive;
        }

        // Optional: unlock/lock cursor for simulator
        Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isActive;
    }
}