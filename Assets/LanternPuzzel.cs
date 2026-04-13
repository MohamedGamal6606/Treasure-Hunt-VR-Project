using UnityEngine;
using UnityEngine.SceneManagement; // needed for scene reload
using System.Collections;

public class LanternSwapPuzzle : MonoBehaviour {
    public GameObject blueLantern;
    public GameObject redLantern;
    public GameObject keyObject;
    public ParticleSystem rejectEffect;
    public GameObject explosionEffect;   // prefab for explosion

    private bool solved = false;

    void OnTriggerEnter(Collider other) {
        if (solved) return;

        if (other.gameObject == blueLantern) {
            // Snap lantern into holder
            SnapLantern(other.transform);

            // Correct choice → reveal key
            keyObject.SetActive(true);
            solved = true;
        }
        else if (other.gameObject == redLantern) {
            // Snap lantern into holder
            SnapLantern(other.transform);

            // Wrong choice → reject + explosion
            if (rejectEffect != null) {
                rejectEffect.Play();
            }

            if (explosionEffect != null) {
                GameObject exp = Instantiate(
                    explosionEffect,
                    transform.position + Vector3.up * 1f,
                    Quaternion.identity
                );

                ParticleSystem expPS = exp.GetComponent<ParticleSystem>();
                if (expPS != null) {
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

            // 🔄 Restart after 1 second delay
            StartCoroutine(RestartAfterDelay(0.1f));
        }
    }

    void SnapLantern(Transform lanternTransform) {
        lanternTransform.position = transform.position;
        lanternTransform.rotation = transform.rotation;
        lanternTransform.SetParent(transform); // attach to holder
    }

    IEnumerator RestartAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}