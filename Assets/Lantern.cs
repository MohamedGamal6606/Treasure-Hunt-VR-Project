using UnityEngine;

public class LanternSlot : MonoBehaviour {
    public bool isFilled = false;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Lantern")) {
            // Snap lantern into place
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
            other.transform.SetParent(transform);

            isFilled = true;
        }
    }
}