using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public List<GameObject> woodPlanks; 
    public GameObject particles;
    private float timer = 0;
    public float burnTime = 6f;

    private void Start() {
        particles.SetActive(false);
    }

    void FixedUpdate() 
    {
        if(PlayerInventory.Instance.onFire)
        {
            particles.SetActive(true);
            timer += Time.deltaTime;
            MenuManager.Instance.achievement2 = true;

            if(timer > burnTime)
            {
                foreach(GameObject obj in woodPlanks)
                {
                    Rigidbody objRB = obj.GetComponent<Rigidbody>();
                    objRB.isKinematic = false;
                }
                particles.SetActive(false);
                Destroy(this);
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player" && PlayerInventory.Instance.Item?.name == "Matchbox")
            PlayerInventory.Instance.possibleFire = true;
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Player" && PlayerInventory.Instance.Item?.name == "Matchbox")
            PlayerInventory.Instance.possibleFire = false;
    }
}

