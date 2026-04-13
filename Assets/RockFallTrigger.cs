using System.Collections;
using UnityEngine;

using System.Collections;
using UnityEngine;

public class RockFallTrigger : MonoBehaviour
{
    public Rigidbody[] rocks;
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        if (!triggered && other.CompareTag("Player"))
        {
            Debug.Log("PLAYER DETECTED - DROPPING ROCKS");

            triggered = true;
            StartCoroutine(DropRocks());
        }
    }

    IEnumerator DropRocks()
    {
        foreach (Rigidbody rock in rocks)
        {
            rock.isKinematic = false;
            yield return new WaitForSeconds(1.5f);
        }
    }
}