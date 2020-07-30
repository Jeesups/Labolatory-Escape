using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChanger : MonoBehaviour
{
    // Start is called before the first frame update
    Scene scene;
    
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
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
