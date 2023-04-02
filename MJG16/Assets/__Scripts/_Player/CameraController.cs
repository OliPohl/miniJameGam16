using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
   
    public Vector2 camX;

    public float offsetY = 0;
    public Vector2 camY;
    private float CamZ;

    public bool camLock = false;

    private void Start() 
    {
        CamZ = gameObject.transform.position.z;
    }
    
    private void FixedUpdate() 
    {
         if(!(camLock))
         {
             float x = Mathf.Clamp(player.transform.position.x, camX.x, camX.y);
             float y = Mathf.Clamp(player.transform.position.y, camY.x,camY.y);
             gameObject.transform.position = new Vector3 (x,y + offsetY, CamZ);
         }
    }
}
