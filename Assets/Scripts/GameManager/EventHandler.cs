using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{

    [SerializeField] private PlayerController playerObject;
    private LevelChanger levelChanger;

    //Making this class as Singleton
    public static EventHandler current;
    private void Awake() {
        current = this;
    }


    private void Start()
    {
        levelChanger = GetComponent<LevelChanger>();
        playerObject = playerObject.gameObject.GetComponent<PlayerController>();
    }

    private void Update()
    {
        playerObject.OnChangeLevel += PlayerObject_OnChangeLevel;
    }

    private void PlayerObject_OnChangeLevel()
    {
        //levelChanger.LoadNextScene();
    }
}
