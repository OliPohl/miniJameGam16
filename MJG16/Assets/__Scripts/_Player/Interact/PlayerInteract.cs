using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [field: SerializeField] private bool _drawDebugGizmos = true;
    private  PlayerInventory _playerInventory;

    public static IInteractable interactableObject { get; private set; }
    private GameObject currentObject;

    public static PlayerInteract Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void OnInteract()
    {
        if (interactableObject != null)
        {
            InteractWithObject(interactableObject);
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


    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}