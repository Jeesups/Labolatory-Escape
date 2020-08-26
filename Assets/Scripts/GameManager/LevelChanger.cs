using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChanger : MonoBehaviour
{
    //Main objective: Change level according to specific event

    //It works but it would require refactoring since it works only when player hits finish point, but what will happend if player will die?
    // Start is called before the first frame update

    [SerializeField] private PlayerController playerController;

    [SerializeField] private KillBoxController killBoxController;

    Scene scene;
    int currentSceneIndex;
    int newSceneIndex;
    private bool isChangingLevel;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        currentSceneIndex = scene.buildIndex;
        playerController = playerController.GetComponent<PlayerController>();
        killBoxController = killBoxController.GetComponent<KillBoxController>();
        
        isChangingLevel = false;
        newSceneIndex = currentSceneIndex;
    }

    private void Update()
    {      
        playerController.OnChangeLevel += PlayerController_OnChangeLevel;
        killBoxController.OnPlayerDetected += KillBoxController_OnPlayerDetected;

        if (isChangingLevel)
        {
            LoadNextScene(newSceneIndex);
            isChangingLevel = false;
        }
        
        
        
    }

    private void KillBoxController_OnPlayerDetected()
    {
        newSceneIndex = 0;
        isChangingLevel = true;
    }

    private void PlayerController_OnChangeLevel()
    {
        newSceneIndex = currentSceneIndex + 1;
        isChangingLevel = true;
    }

    public void LoadNextScene(int targetScene){
        if(targetScene >= SceneManager.sceneCountInBuildSettings)
        {
            RestartGame();
            return;
        }

        SceneManager.LoadScene(targetScene);
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }


    private void KillPlayer(){
        RestartGame();
    }
}
