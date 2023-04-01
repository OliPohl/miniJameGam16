using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class StoneInteract : MonoBehaviour, IInteractable
{
    private PlayerInventory inventory;

    void Start() 
    {
        inventory = PlayerInventory.Instance.GetComponent<PlayerInventory>();
    }
    
    public string Data()
    {
        if(inventory.Item == gameObject)
            return "Throw Stone";
        else
            return "Pickup Stone";
    }

    public void Interact()
    {
        if(inventory.Item == gameObject)
            inventory.ThrowObject(gameObject);
        else
            inventory.TakeObject(gameObject);
    }
}
