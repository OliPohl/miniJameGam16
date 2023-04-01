using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class StoneInteract : MonoBehaviour, IInteractable
{

    public string Data()
    {
        if(PlayerInventory.Instance.Item == gameObject)
            return "Throw Stone";
        else
            return "Pickup Stone";
    }

    public void Interact()
    {
        if(PlayerInventory.Instance.Item == gameObject)
            PlayerInventory.Instance.ThrowObject(gameObject);
        else
            PlayerInventory.Instance.TakeObject(gameObject);
    }
}
