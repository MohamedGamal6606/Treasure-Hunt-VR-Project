using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSFXPlayer : MonoBehaviour
{
    public AudioClip[] sfxClips;   // Assign your SFX in the Inspector
    public float interval = 10f;   // Time between plays (seconds)

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomSFX());
    }

    IEnumerator PlayRandomSFX()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            if (sfxClips.Length == 0) continue;

            int randomIndex = Random.Range(0, sfxClips.Length);
            AudioClip clip = sfxClips[randomIndex];

            audioSource.PlayOneShot(clip);
        }
    }
}