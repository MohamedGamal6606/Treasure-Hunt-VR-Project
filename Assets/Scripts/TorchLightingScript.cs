using Unity.VisualScripting;
using UnityEngine;

public class TorchLightingScript : MonoBehaviour
{
    public GameObject fireParticles;
    public GameManager gameManager;
    public string torchName; // Unique identifier for the torch

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Torch"))
        {
            fireParticles.SetActive(true);
            if(gameManager != null && !gameManager.isTorchLit.Contains(torchName))
                gameManager.isTorchLit.Add(torchName);
        }
    }
}
