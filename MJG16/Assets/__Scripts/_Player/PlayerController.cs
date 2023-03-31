using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 PlayerDirection { get; set; }
    public static PlayerController Instance;
    private Animator animator;
    // PLAYER VARS
    [SerializeField] private float speed=5.0f;
    private Rigidbody rb;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
        Animate();
    }
    private void Move()
    {
        Vector2 _moveInput = PlayerDirection * speed;
        Vector2 _position =  transform.position;
        _moveInput.y = 0.0f;
        // rb.velocity = _moveInput * speed;
        rb.MovePosition(_position + _moveInput);
        Debug.Log(PlayerDirection);
    }
    
    private void Animate()
    {
        // if jumping trigger jump
        // if pickup trigger pickup
        // if running (velocity > 1 Bool is running)
        // if life < 0 isdying
        // if action.Dance > random dance
        // if action.throw > set trigger Throwing
    }
    // input manager 
    // movement WASD and animate()
    // actions / actionmap
    // functions mapControl
    // Animation State // animator!!

    // healtManage ?
}
