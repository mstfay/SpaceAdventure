using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip gold;
    public AudioClip gameOver;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void JumpSound()
    {
        audioSource.clip = jump;
        audioSource.Play();
    }

    public void GoldSound()
    {
        audioSource.clip = gold;
        audioSource.Play();
    }

    public void GameOverSound()
    {
        audioSource.clip = gameOver;
        audioSource.Play();
    }
}
