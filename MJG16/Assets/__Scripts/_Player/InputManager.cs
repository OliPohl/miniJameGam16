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
    public void OnActions(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            // playerController.Action[x]();
        }
    }
 }
