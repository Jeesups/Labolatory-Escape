using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] Vector3 offset;
    void Start()
    {
        offset = playerObject.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerObject.transform.position - offset;
        
    }
}
