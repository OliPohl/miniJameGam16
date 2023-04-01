using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [field: SerializeField] private bool _drawDebugGizmos = true;
    [field: SerializeField] private  PlayerInventory _playerInventory;

    public static IInteractable interactableObject { get; private set; }
    private GameObject currentObject;


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
        if(other.tag == "Interactable" && interactableObject == null)
        {
            currentObject = other.gameObject;
            interactableObject = other.GetComponent<IInteractable>();
            Debug.Log(interactableObject);
        }
    }


    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Interactable" && currentObject == other.gameObject)
        {
            currentObject = null;
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

            Gizmos.DrawCube(transform.position, transform.localScale);
        }
    }
}