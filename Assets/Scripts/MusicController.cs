using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    //Creating Singleton
    //SAVE IT, IT ALLOWS ME TO PLAY MUSIC BETWEEN SCENES.(I will use it in different project)

    private static MusicController instance = null;
    private AudioSource audio;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }   
        if(instance == this)
        {
            return;
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Stop();
        audio.Play();
    }

}
