using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private float vol = 0.3f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = vol;
    }

    public void playSound(AudioClip sound)
    {
        if (audioSource.isPlaying && audioSource.clip == sound)
        {
            return;
        }
        else
        {
            audioSource.clip = sound;
            audioSource.Play();
        }
    }

    public void PlayOneshot(AudioClip sound)
    {
        if (audioSource.isPlaying && audioSource.clip == sound)
        {
            return;
        }
        else
        {
            audioSource.clip = sound;
            audioSource.PlayOneShot(sound, vol);
        }
    }

    public void stopPlaying(AudioClip sound)
    {
        if (audioSource.isPlaying && audioSource.clip == sound)
        {
            audioSource.Stop();
        }
    }
}
