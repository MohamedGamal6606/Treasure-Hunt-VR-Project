using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRTooltipSimple : MonoBehaviour
{
    public GameObject tooltipCanvas;
    public Transform playerCamera;

    public float activationDistance = 5f;
    public float displayDistance = 1.5f;

    private XRBaseInteractable interactable;
    private bool hasBeenShown = false;

    void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
    }

    void OnEnable()
    {
        interactable.hoverEntered.AddListener(OnHoverEnter);
    }

    void OnDisable()
    {
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
    }

    void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (hasBeenShown) return;

        float distance = Vector3.Distance(playerCamera.position, transform.position);

        if (distance <= activationDistance)
        {
            ShowTooltip();
            hasBeenShown = true;
        }
    }

    /*void ShowTooltip()
    {
        tooltipCanvas.SetActive(true);

        tooltipCanvas.transform.position =
            playerCamera.position + playerCamera.forward * displayDistance;

        tooltipCanvas.transform.rotation =
            Quaternion.LookRotation(playerCamera.forward);
    }*/
   void ShowTooltip()
    {
         tooltipCanvas.SetActive(true);
     }

    public void CloseTooltip()
    {
        tooltipCanvas.SetActive(false);
    }
}

