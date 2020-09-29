using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landingSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
   
    
    }
    //TODO: Fix few bugs
    //BUGLIST: After hitting moving platform it should also play
    public void SoundOnJump(){
        audioSource.Stop();
        audioSource.PlayOneShot(jumpSound);
    }

    public void SoundOnLand(){
        audioSource.Stop();
        audioSource.PlayOneShot(landingSound);
    }


}
