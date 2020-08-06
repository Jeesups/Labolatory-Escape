using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChanger : MonoBehaviour
{
    //Main objective: Change level according to specific event
    //TODO: make delegate and event handler.
    // Start is called before the first frame update

    EventHandler eventHandler;

    Scene scene;
    
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        eventHandler = GetComponent<EventHandler>();
    }

    void LoadNextScene(){
        if(scene.buildIndex <= SceneManager.sceneCountInBuildSettings - 1){
            SceneManager.LoadScene(scene.buildIndex+1);
        }
        else if(scene.buildIndex == SceneManager.sceneCountInBuildSettings - 1){
            RestartGame();
        }
    }
    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
