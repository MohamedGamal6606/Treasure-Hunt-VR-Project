using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    public Camera playerCamera;
    public float distance = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked 🔥");

            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distance))
            {
                Debug.Log("Hit: " + hit.collider.name);
            }
        }
    }
}