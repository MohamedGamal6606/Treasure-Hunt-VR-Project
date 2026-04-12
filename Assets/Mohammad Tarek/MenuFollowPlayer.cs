using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SettingsMenuToggle : MonoBehaviour
{
    public GameObject settingsCanvas;
    public XRInteractionManager interactionManager;
    public InputActionReference triggerAction;
    void Update()
    {
        if (triggerAction.action.WasPressedThisFrame())
        {
            ToggleMenu();
        }
    }

   public void ToggleMenu()
    {
        
        settingsCanvas.SetActive(!settingsCanvas.activeSelf);

    }
}