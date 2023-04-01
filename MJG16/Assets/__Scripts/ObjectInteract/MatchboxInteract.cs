using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class MatchboxInteract : MonoBehaviour, IInteractable
{
    private Vector3 startPos;
    void Start() {
        startPos = transform.position;
    }

    public string Data()
    {
        if(PlayerInventory.Instance.possibleFire)
            return "Light on Fire";
        else if(PlayerInventory.Instance.Item == gameObject)
            return "Drop Matchbox";
        else
            return "Pickup Matchbox";
    }

    public void Interact()
    {
        if(PlayerInventory.Instance.Item == gameObject && !(PlayerInventory.Instance.possibleFire))
            PlayerInventory.Instance.TakeObject(null);
        else if(PlayerInventory.Instance.possibleFire)
        {
            PlayerInventory.Instance.TakeObject(null);
            PlayerInventory.Instance.StartFire();
            Destroy(gameObject, 0.5f);
        }
        else
            PlayerInventory.Instance.TakeObject(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log(other);
        if(other.tag == "Death" && PlayerInventory.Instance.Item?.name == "Matchbox")
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