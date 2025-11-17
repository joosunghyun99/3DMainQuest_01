using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : GenericSingleton<SoundManager>
{
    [SerializeField] private AudioClip coinClip;
    private AudioSource audioSource;

    private void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCoinSound() 
    {
        audioSource.PlayOneShot(coinClip);
    }
}
