using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private void Awake() {
        // INSTANCE ? 
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            PlayerController.Instance.PlayerDirection= context.ReadValue<Vector2>();
            
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
