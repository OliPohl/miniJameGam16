using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [field: SerializeField] private bool _drawDebugGizmos = true;
    [field: SerializeField] private  PlayerInventory _playerInventory;

    public static IInteractable interactableObject { get; private set; }


    private void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (interactableObject != null)
            {
                InteractWithObject(interactableObject);
            }
        }
    }


    private void InteractWithObject(IInteractable interactableObject)
    {
        interactableObject?.Interact();
    }


    private void OnTriggerStay(Collider other) 
    {
        if(other.tag == "Interactable")
        {
            interactableObject = other.GetComponent<IInteractable>();
        }
    }


    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Interactable")
        {
            interactableObject = null;
        }
    }


    private void OnDrawGizmos()
    {
        if (_drawDebugGizmos)
        {

            Gizmos.color = Color.yellow;

            if(interactableObject != null)
                Gizmos.color = Color.red;

            Gizmos.DrawCube(transform.position, GetComponent<BoxCollider>().size);
        }
    }
}