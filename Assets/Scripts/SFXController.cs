using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioClip laserBeamEffect;
    private AudioSource _compAudioSource;
    void Awake()
    {
        _compAudioSource = GetComponent<AudioSource>();
    }
    public void PlayLaserBeamEffect()
    {
        _compAudioSource.clip = laserBeamEffect;
        _compAudioSource.Play();
    }
}
