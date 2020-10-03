using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool musicEnabled;
    public AudioManager audioManager;
    public AudioSource audioSource;

    public float volume = 1;

    private void Start()
    {
        musicEnabled = true;
    }

    public void ToggleMusic()
    {
        if (musicEnabled) musicEnabled = false;
        else musicEnabled = true;
    }

    public void PlayClip(AudioClip clip)
    {
        if (musicEnabled)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }


}
