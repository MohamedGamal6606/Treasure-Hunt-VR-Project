using UnityEngine;

public class LanternPuzzleManager : MonoBehaviour {
    public LanternSlot[] slots;        // Reference to all slots
    public GameObject dynamiteObject;  // Dynamite in the scene (disabled at start)

    private bool activated = false;

    void Update() {
        if (!activated && AllSlotsFilled()) {
            ActivateDynamite();
            activated = true;
        }
    }

    bool AllSlotsFilled() {
        foreach (var slot in slots) {
            if (!slot.isFilled) return false;
        }
        return true;
    }

    void ActivateDynamite() {
        dynamiteObject.SetActive(true);   // Enable the dynamite
    }
}