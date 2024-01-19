using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform cameraPosition;


    void Update()
    {
        //mves the camera
        transform.position = cameraPosition.position;    
    }
}
