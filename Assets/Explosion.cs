using System.Collections;
using UnityEngine;

public class ExplosionZone : MonoBehaviour
{
    public GameObject smokeEffect;
    public GameObject explosionEffect;
    public GameObject rockWall;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        if (triggered) return;

        if (other.CompareTag("Dynamite"))
        {
            triggered = true;
            StartCoroutine(ExplodeSequence(other.gameObject));
        }
    }

    IEnumerator ExplodeSequence(GameObject dynamite)
    {
        // 💨 START SMOKE
        if (smokeEffect != null)
        {
            Debug.Log("Smoke ON");
            smokeEffect.SetActive(true);

            ParticleSystem smokePS = smokeEffect.GetComponent<ParticleSystem>();
            if (smokePS != null)
            {
                smokePS.Clear();
                smokePS.Play();
            }
        }

        // ⏳ WAIT BEFORE EXPLOSION
        yield return new WaitForSeconds(10f);

        // 💥 EXPLOSION
        if (explosionEffect != null)
        {
            GameObject exp = Instantiate(
                explosionEffect,
                transform.position + Vector3.up * 1f,
                Quaternion.identity
            );

            ParticleSystem expPS = exp.GetComponent<ParticleSystem>();
            if (expPS != null)
            {
                expPS.Clear();
                expPS.Play();
            }
                // 🔊 Play explosion sound
            AudioSource audioSource = exp.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }

        // 🪨 DESTROY WALL
        if (rockWall != null)
        {
            Destroy(rockWall);
        }

        // 💣 DESTROY DYNAMITE
        if (dynamite != null)
        {
            Destroy(dynamite);
        }

        // 💨 STOP SMOKE
        if (smokeEffect != null)
        {
            smokeEffect.GetComponent<ParticleSystem>()?.Stop();
            smokeEffect.SetActive(false);
        }
    }
}