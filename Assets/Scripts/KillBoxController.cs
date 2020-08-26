using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class KillBoxController : MonoBehaviour
{
    // Start is called before the first frame update

    public delegate void OnPlayerDetectedEventHandler();

    public event OnPlayerDetectedEventHandler OnPlayerDetected;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            OnPlayerDetected?.Invoke();
        }
    }
}
