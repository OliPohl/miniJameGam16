using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float PlayerDirection { get; set; }
    
    public static PlayerController Instance;
    private Animator animator;
    // PLAYER VARS
    [SerializeField]private float FlipSpeedLerp = 5f;
    private float FlipTimeStamp = 0f;
    private float FlipLerpDuration = 3.0f;
    [SerializeField] private float speed=5.0f;
    [SerializeField] private float jumpPower= 20.0f;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private Transform playerFlipModel;
    [SerializeField] private LayerMask groundLayer;
    private float Gravity  = 9.81f;
    private bool isFacingRight = true;
    public bool isJumping = false;
    private Rigidbody rb;
    private Quaternion localRot = Quaternion.Euler(0, 0, 0);

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
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
        Animate();
        Flip();
        
    }
    private void Move()
    {
       
                
        rb.velocity = new Vector2(PlayerDirection * speed, rb.velocity.y);
        
    }
    
    private void Animate()
    {
        /// FACING ANIMATION ///
        if(PlayerDirection <-0.2f || PlayerDirection > 0.2f)
        {
            animator.SetBool("isRunning", true);
        }else{
            animator.SetBool("isRunning", false);
        }
        /// JUMPING ANIMATION ///
        if(isJumping)
        {
            animator.SetTrigger("Jumping");
            isJumping=false;
        }
        // if jumping trigger jump
        // if pickup trigger pickup
        // if running (velocity > 1 Bool is running)
        // if life < 0 isdying
        // if action.Dance > random dance
        // if action.throw > set trigger Throwing
    }
    private bool isGrounded()
    {
        return (Physics.OverlapBox(groundcheck.position, transform.localScale / 4, Quaternion.identity, groundLayer).Length>0);
    }
    private void Flip()
    {
        if(!isFacingRight && PlayerDirection >0f)
        {
            isFacingRight = !isFacingRight;
            
            localRot = Quaternion.Euler(0f,90f,0f);
            FlipTimeStamp = 0f;
            
        } else if(isFacingRight && PlayerDirection < 0f)
        {
            isFacingRight = !isFacingRight;
            localRot = Quaternion.Euler(0f,-90f,0f);
            FlipTimeStamp = 0f;
            
            
        }
        
        playerFlipModel.localRotation = Quaternion.Lerp(playerFlipModel.rotation,localRot,FlipTimeStamp*FlipSpeedLerp / FlipLerpDuration);
        FlipTimeStamp += Time.fixedDeltaTime;
    
        
    }
    public void PlayerJump(float jumpModifier)
    {
       
       if(isGrounded())
       {
           
            isJumping = true;
            Vector3 vel = transform.up * jumpPower;
            rb.AddForce(rb.velocity + vel, ForceMode.Impulse);
       }
       if(jumpModifier == 0.5f)
        {
           
            isJumping = false;
            // rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpPower* jumpModifier);
        }
    }
    // actions / actionmap
    // functions mapControl
    // Animation State // animator!!

    // healtManage ?
}
