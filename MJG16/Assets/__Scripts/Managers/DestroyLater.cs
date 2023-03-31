using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLater : MonoBehaviour
{
    private float delay = 10f;
    private float timer;

    void Start()
    {
        timer = Time.time + delay;
    }


    void FixedUpdate()
    {
        if(timer < Time.time)
            Destroy(gameObject);
    }
}
