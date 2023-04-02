using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ropes : MonoBehaviour
{
    public List<GameObject> ropes; 


    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player" 
            && PlayerInventory.Instance.Item?.name == "Scissors" 
            && ropes[0].GetComponent<Rigidbody>().isKinematic)
        {
            foreach(GameObject obj in ropes)
            {
                Rigidbody objRB = obj.GetComponent<Rigidbody>();
                objRB.isKinematic = false;
            }
            MenuManager.Instance.achievement5 = true;
        }
    }
}

