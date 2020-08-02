using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;


    [SerializeField] AudioController audioController;
    float movementSpeed = 1000f;
    float jumpForce = 550f;


    enum PlayerMovementState{
        Landed,
        MidAir
        
    }
    bool isPlayerInAir = false; // alternative to enum, since upper enum owns only two states and it could be replaced by boolean

    [SerializeField] PlayerMovementState playerMovementState = PlayerMovementState.Landed;
   void Start()
    {     
        rigidbody = GetComponent<Rigidbody>();
        audioController = GetComponent<AudioController>();
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


    }
    void Jump()
    {
          if(Input.GetKey(KeyCode.Space) && playerMovementState == PlayerMovementState.Landed){
            audioController.SoundOnJump();
            rigidbody.AddForce(new Vector3(0f,jumpForce,0f));
            playerMovementState = PlayerMovementState.MidAir;
        }
    }


    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag.Equals("Friendly")){
            playerMovementState = PlayerMovementState.Landed;
            audioController.SoundOnLand();
        }    
    }
}
