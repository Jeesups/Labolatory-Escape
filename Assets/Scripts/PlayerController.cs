using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;

    float movementSpeed = 1000f;
    float jumpForce = 550f;


    enum PlayerMovementState{
        Landed,
        MidAir
        
    }

    [SerializeField] PlayerMovementState playerMovementState = PlayerMovementState.Landed;
   void Start()
    {     
        rigidbody = GetComponent<Rigidbody>();
       
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

            rigidbody.AddForce(new Vector3(0f,jumpForce,0f));
            playerMovementState = PlayerMovementState.MidAir;
        }
    }


    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag.Equals("Friendly")){
            playerMovementState = PlayerMovementState.Landed;
        }    
    }
}
