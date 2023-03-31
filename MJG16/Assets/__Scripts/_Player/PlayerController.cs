using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 PlayerDirection {get; set;}
    public static PlayerController Instance;
    private void Awake() {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = null;
    }
    private void FixedUpdate() {
        Move();
        Animate();
    }
    private void Move()
    {

    }
    private void Animate()
    {
        
    }
    // input manager 
    // movement WASD and animate()
    // actions / actionmap
    // functions mapControl
    // Animation State // animator!!

    // healtManage ?
}
