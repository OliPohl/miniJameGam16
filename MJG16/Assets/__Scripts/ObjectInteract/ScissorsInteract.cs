using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ScissorsInteract : MonoBehaviour, IInteractable
{
    private Vector3 startPos;
    void Start() {
        startPos = transform.position;
    }

    public string Data()
    {
        if(PlayerInventory.Instance.Item == gameObject)
            return "Drop Scissors";
        else
            return "Pickup Scissors";
    }

    public void Interact()
    {
        if(PlayerInventory.Instance.Item == gameObject)
            PlayerInventory.Instance.TakeObject(null);
        else
            PlayerInventory.Instance.TakeObject(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Death" && PlayerInventory.Instance.Item?.name == "Scissors")
        {
            ResetPos();
        }
    }

    private void ResetPos()
    {
        transform.SetParent(null);
        transform.position = startPos;
    }
}