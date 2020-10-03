using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    public void playSound(AudioClip sound)
    {
        audioSource.clip = sound;
        audioSource.Play();
    }
}
