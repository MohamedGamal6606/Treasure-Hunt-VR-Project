using System.Collections;
using UnityEngine;

public class RockFallTrigger : MonoBehaviour
{
    public Rigidbody[] rocks;
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(DropRocks());
        }
    }

    IEnumerator DropRocks()
    {
        foreach (Rigidbody rock in rocks)
        {
            rock.isKinematic = false;
            yield return new WaitForSeconds(1.5f); // delay between rocks
        }
    }
}