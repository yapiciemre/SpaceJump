using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectControl : MonoBehaviour
{
    public AudioClip jumping;
    public AudioClip gold;
    public AudioClip gameOver;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void JumpingAudio()
    {
        audioSource.clip = jumping;
        audioSource.Play();
    }

    public void GoldAudio()
    {
        audioSource.clip = gold;
        audioSource.Play();
    }

    public void GameOverAudio()
    {
        audioSource.clip = gameOver;
        audioSource.Play();
    }
}
