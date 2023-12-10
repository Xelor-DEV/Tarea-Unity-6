using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip background_music;
    private AudioSource _compAudioSource;
    void Awake()
    {
        _compAudioSource = GetComponent<AudioSource>();
        _compAudioSource.clip = background_music;
        _compAudioSource.Play();
    }
}
