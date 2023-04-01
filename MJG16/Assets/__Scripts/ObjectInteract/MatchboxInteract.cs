using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class MatchboxInteract : MonoBehaviour, IInteractable
{
    private Vector3 startPos;
    private bool possibleFire = false;
    void Start() {
        startPos = transform.position;
    }

    public string Data()
    {
        if(PlayerInventory.Instance.Item == gameObject && possibleFire)
            return "Light on Fire";
        else if(PlayerInventory.Instance.Item == gameObject)
            return "Drop Matchbox";
        else
            return "Pickup Matchbox";
    }

    public void Interact()
    {
        if(PlayerInventory.Instance.Item == gameObject)
            PlayerInventory.Instance.TakeObject(null);
        else if(possibleFire)
        {
            PlayerInventory.Instance.TakeObject(null);
            PlayerInventory.Instance.StartFire();
            Destroy(gameObject);
        }
        else
            PlayerInventory.Instance.TakeObject(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if(other.tag == "Death" && PlayerInventory.Instance.Item?.name == "Matchbox")
        {
            ResetPos();
        }
        else if(other.tag == "Wood" && PlayerInventory.Instance.Item?.name == "Matchbox")
        {
            possibleFire = true;
        }
        else
        {
            possibleFire = false;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Wood" && PlayerInventory.Instance.Item?.name == "Matchbox")
        {
            possibleFire = false;
        }
    }

    private void ResetPos()
    {
        transform.SetParent(null);
        transform.position = startPos;
    }
}