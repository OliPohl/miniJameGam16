using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [field: SerializeField] private bool _drawDebugGizmos = true;
    [field: SerializeField] private  PlayerInventory _playerInventory;

    private IInteractable interactableObject;


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


    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Interactable" && other != _playerInventory.Item)
        {
            interactableObject = other.GetComponent<IInteractable>();
        }
    }


    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Interactable" && other != _playerInventory.Item)
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