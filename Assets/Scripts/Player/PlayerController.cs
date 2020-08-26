using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour

{
    public delegate void OnChangeLevelEvent();

    public event OnChangeLevelEvent OnChangeLevel;
    
    
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] AudioController audioController;
    float movementSpeed = 1000f;
    float jumpForce = 550f;

    public enum PlayerExistingState{
        Alive,
        Dying
    }

    public enum PlayerMovementState{
        Landed,
        MidAir
    }

    bool isPlayerInAir = false; // alternative to enum, since upper enum owns only two states and it could be replaced by boolean

    private PlayerMovementState playerMovementState = PlayerMovementState.Landed;
    [SerializeField] private PlayerExistingState playerExistingState = PlayerExistingState.Alive;
   void Start()
    {     
        rigidbody = GetComponent<Rigidbody>();
        audioController = GetComponent<AudioController>();

        //Shoot events
        
    }
    void Update()
    {
        CheckInput();
    }


    void CheckInput(){
        Move();
        Jump();
    }
    void Move()
    {
        if(Input.GetKey(KeyCode.A)){
            rigidbody.AddForce(new Vector3(-movementSpeed * Time.deltaTime,0f,0f));
        }
        if(Input.GetKey(KeyCode.D)){
            rigidbody.AddForce(new Vector3(movementSpeed * Time.deltaTime,0f,0f));
        }
        //TEMPORARY - MOVE IT TO ANOTHER CLASS (GAME MANAGER)
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }


    }
    void Jump()
    {
          if(Input.GetKey(KeyCode.Space) && playerMovementState == PlayerMovementState.Landed){
            audioController.SoundOnJump();
            rigidbody.AddForce(new Vector3(0f,jumpForce,0f));
            playerMovementState = PlayerMovementState.MidAir;
        }
    }

    public PlayerExistingState GetCurrentExistingState(){
        return playerExistingState;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag.Equals("Friendly")){
            playerMovementState = PlayerMovementState.Landed;
            audioController.SoundOnLand();
        }
        if(other.transform.tag.Equals("Pit")){
            playerExistingState = PlayerExistingState.Dying;
        }
        if (other.transform.tag.Equals("Finish"))
        {
            OnChangeLevel?.Invoke();
        }
    }
}
