using UnityEngine;

public class ShowQuestion : MonoBehaviour
{
    public GameObject questionUI;

    private void OnMouseDown()
    {
        questionUI.SetActive(true);
    }
}