using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class KeyClick : MonoBehaviour
{
    public QuestionManager manager;
    public int questionIndex;

    private XRGrabInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnClicked);
    }

    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnClicked);
    }

    private void OnClicked(SelectEnterEventArgs args)
    {
        Debug.Log("Key clicked: " + gameObject.name);
        manager.ShowQuestion(gameObject, questionIndex);
    }
}