using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour
{
    public float maxPitch = 1f;
    public float minPitch = 1f;

    public List<AudioClip> possibleSounds;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomizedSound()
    {
        if (audioSource == null || possibleSounds.Count == 0)
        {
            return;
        }

        audioSource.pitch = Random.Range(minPitch, maxPitch);

        int randomSoundIndex = Random.Range(0, possibleSounds.Count);

        audioSource.PlayOneShot(possibleSounds[randomSoundIndex]);
    }
}
