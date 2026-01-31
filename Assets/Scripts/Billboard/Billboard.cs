using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Billboard : MonoBehaviour
{
    private Transform cameraTransform;
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    
    void Update()
    {
        transform.LookAt(cameraTransform);
        transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
    }
}
