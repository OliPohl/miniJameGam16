using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [field: SerializeField] private bool _drawDebugGizmos = true;
    public GameObject Item { get; private set; }
    public static PlayerInventory Instance;
    public float throwPower = 5f;


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


    public void TakeObject(GameObject newObj)
    {
        Item = newObj;
        foreach (Transform trans in transform)
        {
            Rigidbody transRB = trans.GetComponent<Rigidbody>();
            transRB.isKinematic = false;
            trans.gameObject.GetComponentsInChildren<Collider>().Any(x => x.enabled = true);

            trans.SetParent(null);
        }

        if (Item != null)
        {
            Item.GetComponent<Rigidbody>().isKinematic = true;
            Item.transform.SetParent(transform);
            Item.GetComponentsInChildren<Collider>().Any(x => x.enabled = false);
        }
    }


    public void ThrowObject(GameObject Obj)
    {
        Rigidbody objRB = Obj.transform.GetComponent<Rigidbody>();
        objRB.isKinematic = false;
        Obj.transform.gameObject.GetComponentsInChildren<Collider>().Any(x => x.enabled = true);

        Obj.transform.SetParent(null);
        Item = null;
        objRB.AddForce(transform.forward * throwPower);
    }


    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }


    private void OnDrawGizmos()
    {
        if (_drawDebugGizmos)
        {
            Gizmos.color = Color.green;

            if(Item != null)
                Gizmos.color = Color.blue;

            Gizmos.DrawCube(transform.position, transform.localScale);
        }
    }
}