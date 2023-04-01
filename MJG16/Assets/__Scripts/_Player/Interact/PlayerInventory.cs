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
    public float throwPower = 1000f;


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


    void FixedUpdate() 
    {
        if(Item != null)
        {
            if (Vector3.Distance(transform.localPosition, Vector3.zero) < 0.01f)
                Item.transform.localPosition = Vector3.MoveTowards(Item.transform.localPosition, Vector3.zero, Time.deltaTime);
        }
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
        // Obj.transform.position = Obj.transform.position * 1;
        float dir;
        
        if(PlayerController.Instance.isFacingRight)
            dir = 1;
        else
            dir = -1;

        objRB.AddForce(dir * throwPower, 0.3f * throwPower, 0f, ForceMode.Acceleration);
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

            Gizmos.DrawCube(transform.position, new Vector3(0.2f,0.2f,0.2f));
        }
    }
}