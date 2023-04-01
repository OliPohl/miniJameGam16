using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private void Awake() {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            PlayerController.Instance.PlayerDirection = context.ReadValue<Vector2>().x;
            
        }
        if(context.canceled)
        {
            PlayerController.Instance.PlayerDirection = 0.0f;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed && !(PlayerController.Instance.isJumping))
        {
            PlayerController.Instance.PlayerJump(1f);
        }
        if(context.canceled)
        {
            PlayerController.Instance.PlayerJump(0.5f);
        }
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            // gamemanager.paused()
        }
    }
    public void OnDrawTape(InputAction.CallbackContext context)
    {
        
        if(context.performed)
        {
            DucttapeDraw.Instance.OnTaping();
        }
         if(context.canceled)
        {
            DucttapeDraw.Instance.OnTaping();
        }
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            PlayerInteract.Instance.OnInteract();
        }
    }
 }
