using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoObject : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDrawGizmos() {
        Gizmos.DrawSphere(transform.position, transform.localScale.x);
    }
}
