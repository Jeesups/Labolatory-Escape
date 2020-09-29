using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicController : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource audio;

    private Scene scene;

    private int currentMusicId;

    [SerializeField] private PlayerController playerController;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        playerController = playerController.GetComponent<PlayerController>();
        playerController.OnChangeLevel += PlayerController_OnChangeLevel;
        scene = SceneManager.GetActiveScene();
        currentMusicId = scene.buildIndex;
        PlayAudio(currentMusicId);
    }

    private void PlayerController_OnChangeLevel()
    {
        CheckCurrentSceneId();        
    }


    private void CheckCurrentSceneId()
    {
        if(scene.buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            currentMusicId = scene.buildIndex;
        }

    }
    private void PlayAudio(int musicID)
    {
        audio.Stop();
        audio.PlayOneShot(clips[musicID]);
    }
    private void Update()
    {
        
    }
}
