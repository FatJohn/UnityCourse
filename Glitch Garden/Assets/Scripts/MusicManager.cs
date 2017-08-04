using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] LevelMusics;

    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load :" + name);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnLevelWasLoaded(int level)
    {
        if (LevelMusics == null)
        {
            return;
        }

        if (level >= LevelMusics.Length)
        {
            return;
        }

        audioSource.clip = LevelMusics[level];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
