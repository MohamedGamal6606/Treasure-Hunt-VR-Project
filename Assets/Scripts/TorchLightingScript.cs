using Unity.VisualScripting;
using UnityEngine;

public class TorchLightingScript : MonoBehaviour
{
    public GameObject fireParticles;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Torch"))
        {
            fireParticles.SetActive(true);
        }
    }
}
