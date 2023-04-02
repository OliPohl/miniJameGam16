using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public Vector3 MousePosition;
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
            PlayerController.Instance.PlayerJump();
        }
        // if(context.canceled)
        // {
        //     PlayerController.Instance.PlayerJump(0.5f);
        // }
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            // gamemanager.paused()
        }
    }
    public void OnAim(InputAction.CallbackContext context)
    {
        if (context.control.device is Mouse)
        {
            Ray ray = Camera.main.ScreenPointToRay(context.ReadValue<Vector2>());
            if (Physics.Raycast(ray, out RaycastHit hit, 50f, LayerMask.GetMask("Default")))
            {
                MousePosition = hit.point;
            }
            
        }
        else if (context.control.device is Gamepad)
        {
            Vector2 input = context.ReadValue<Vector2>();
            MousePosition = new Vector3(input.x, 0f, input.y) * 5;
            Ray ray = Camera.main.ScreenPointToRay(MousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 50f, LayerMask.GetMask("Default")))
            {
                MousePosition = hit.point;
            }
            
        }
    }
    public void OnDrawTape(InputAction.CallbackContext context)
    {
        
        if(context.performed)
        {
            DucttapeDraw.Instance.ButtonChange(true);
        }
         if(context.canceled)
        {
            DucttapeDraw.Instance.ButtonChange(false);
        }
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            PlayerInteract.Instance.OnInteract();
        }
    }


    public void OnMenu(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("Open Menu");
            MenuManager.Instance.ToggleBook();
        }
    }
 }
