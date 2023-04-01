using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLayerScrolling : MonoBehaviour
{
    
     [SerializeField] private float ScrollX = 0.5f;
     [SerializeField] private float ScrollY = 0.5f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    private void FixedUpdate() {
        
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (transform.position.x * ScrollX, transform.position.y * ScrollY);
    }
}
