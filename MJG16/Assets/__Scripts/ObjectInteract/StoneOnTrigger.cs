using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("GlassHouse"))
        {   
            // Debug.Log(other.transform.parent);
            foreach (Transform item in other.transform.parent)
            {
                item.GetComponent<Rigidbody>().isKinematic =false;
                item.GetComponent<Rigidbody>().useGravity= true;
            }
        }
    }
}
