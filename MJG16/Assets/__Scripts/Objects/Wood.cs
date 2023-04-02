using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private AudioClips _audioClips => SoundManager.AudioClips;
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
            if(timer <= Time.deltaTime)
                SoundManager.Instance.PlayAudioAtPosition(_audioClips.fire, transform.position);

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
                SoundManager.Instance.PlayAudioAtPosition(_audioClips.breaking, transform.position);
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

