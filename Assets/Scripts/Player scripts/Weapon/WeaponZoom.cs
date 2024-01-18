using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] float zoomIn = 20f;
    [SerializeField] float zoomOut = 60f;

    [SerializeField] Camera playerCam;


    bool zoomToggle = false;


    private void OnDisable()
    {
        zoomToggle = false;
        playerCam.fieldOfView = zoomOut;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(!zoomToggle)
            {
                zoomToggle = true;
                playerCam.fieldOfView = zoomIn;
            }

            else if(zoomToggle)
            {
                zoomToggle = false;
                playerCam.fieldOfView = zoomOut;
            }
        }
    }
}
