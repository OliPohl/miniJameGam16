using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float PlayerDirection { get; set; }
    public Transform PlayerLastCheckPoint { get; set; }
    public float ZPosition() {return this.transform.position.z;}
    public static PlayerController Instance;
    private Animator animator;
    // PLAYER VARS
    [SerializeField] private float FlipSpeedLerp = 5f;
    private float FlipTimeStamp = 0f;
    private float FlipLerpDuration = 3.0f;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpPower = 20.0f;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private Transform playerFlipModel;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator CameraBlendEffectAnimator;
    // private float Gravity = 9.81f;
    // private float MovementThresholdTimer = 0.0f;
    public bool isFacingRight = false;
    public bool isJumping = false;
    private Rigidbody rb;
    private Quaternion localRot = Quaternion.Euler(0, 0, 0);
    private float timer = 0;
    public float jumpOffset = 0.1f;
    private float danceCoolDown = 0.0f;

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
        // PlayerTransform = gameObject.transform;
        Flip();
        PlayerLastCheckPoint =  new GameObject("StartCheckPoint").transform;
        PlayerLastCheckPoint.position = gameObject.transform.position;
        
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
        if (PlayerDirection < -0.2f || PlayerDirection > 0.2f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        /// JUMPING ANIMATION ///
        if (isJumping)
        {
            animator.SetTrigger("Jumping");
            isJumping = false;
        }
        if(PlayerDirection ==0){
            danceCoolDown += Time.fixedDeltaTime;
        }else{
            danceCoolDown =0;
        }
        if(danceCoolDown >= 4.0f)
        {
            animator.SetTrigger("Dancing");
            danceCoolDown = 0.0f;
        }
    }
    public void SetAnimatorPickup()
    {
        animator.SetTrigger("Pickup");
    }
    public void SetAnimatorThrow()
    {
        animator.SetTrigger("throwing");
    }
    private bool isGrounded()
    {
        return (Physics.OverlapBox(groundcheck.position, transform.localScale, Quaternion.identity, groundLayer).Length > 0);
    }
    private void Flip()
    {
        if (!isFacingRight && PlayerDirection > 0f)
        {
            isFacingRight = !isFacingRight;

            localRot = Quaternion.Euler(0f, 90f, 0f);
            FlipTimeStamp = 0f;

        }
        else if (isFacingRight && PlayerDirection < 0f)
        {
            isFacingRight = !isFacingRight;
            localRot = Quaternion.Euler(0f, -90f, 0f);
            FlipTimeStamp = 0f;


        }

        playerFlipModel.localRotation = Quaternion.Lerp(playerFlipModel.rotation, localRot, FlipTimeStamp * FlipSpeedLerp / FlipLerpDuration);
        FlipTimeStamp += Time.fixedDeltaTime;


    }
    public void PlayerJump()
    {

        if (isGrounded())
        {
            if(timer < Time.time)
            {                
                isJumping = true;
                Vector3 vel = transform.up * jumpPower;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero; 
                rb.AddForce(rb.velocity + vel, ForceMode.Impulse);
                timer = Time.time + jumpOffset;
            }
        }
    }
    // actions / actionmap
    // functions mapControl
    // Animation State // animator!!

    private void OnDeath()
    {
        RespawnTransition();
        
        // respawn to lastCheckPoint
        // reset FaceOrientation
        isFacingRight = false;
        Flip();

    }
    private void RespawnPlayer()
    {
        gameObject.transform.position = PlayerLastCheckPoint.position;
        CameraBlendEffectAnimator.gameObject.SetActive(false);
    }
    private void RespawnTransition()
    {
        // EYES CLOSED EFFECT 
        CameraBlendEffectAnimator.gameObject.SetActive(true);
        CameraBlendEffectAnimator.Play("RespawnCameraBlending");
        RespawnPlayer();
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            OnDeath();
        }
        if (other.CompareTag("MovingPlatform"))
        {
            transform.SetParent(other.transform);
        }
        if (other.CompareTag("CheckPoint"))
        {
            PlayerLastCheckPoint = other.gameObject.transform;
            Debug.Log("CheckPointSystem: Updated - New CheckPoint");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null);
        }
    }
}
