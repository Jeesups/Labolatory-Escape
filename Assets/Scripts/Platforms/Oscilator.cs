using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscilator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;

    [Range(1,0)][SerializeField] float movementFactor; //Goes between 1 and 0;

    [SerializeField] float period = 3f;

    Vector3 startingPosition;
    
    void Start()
    {
        startingPosition = transform.position;
    }



    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon){
            //Epsilon is lowest possible value for float, problem with floats lies in accuracy of floating points
            return; //If its lower than lowest possible value, then end cycle.
        }

        float cycles = Time.time / period; //grows from 0;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f; // rawSinWave goes between -1 and 1, division makes it go from -.5 and .5, adding .5 we make it 0 and 1
        Vector3 offset = movementFactor * movementVector; 
        transform.position = startingPosition + offset; //Adding offset to starting position and exchanging it to existing one.
    }
}