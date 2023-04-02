using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeBoxCollider : MonoBehaviour
{
    [SerializeField] private float TapeDuration = 5.0f;
    private GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TapeDuration);
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("MovingPlatform"))
        {
            Debug.Log("Gotcha");
            other.GetComponent<Animator>().speed = 0.0f;
            obstacle = other.gameObject;
        }
    }
    private void OnDestroy()
    {
        if (obstacle != null)
        {
            obstacle.GetComponent<Animator>().speed = 1.0f;
        }
    }

}
