using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;


    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landingSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SoundOnJump(){
        audioSource.Stop();
        audioSource.PlayOneShot(jumpSound);
    }

    public void SoundOnLand(){
        audioSource.Stop();
        audioSource.PlayOneShot(landingSound);
    }


}
