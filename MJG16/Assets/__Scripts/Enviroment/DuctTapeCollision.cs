using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]

public class DuctTapeCollision : MonoBehaviour
{

    [SerializeField] private float TapeDuration = 5.0f;
       // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TapeDuration);
    }

   
    private void OnDestroy()
    {
        
        DucttapeDraw.Instance.currentTapes--;
    }
}
