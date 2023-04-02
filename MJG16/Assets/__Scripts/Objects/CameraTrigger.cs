using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    private Camera _mainCam;

    
    void Start() 
    {
        _mainCam = Camera.main;
    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            _mainCam.GetComponent<CameraController>().camLock = true;
        }
    }
}
