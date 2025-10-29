using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyChasePhysics : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float catchDistance = 1.5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, target.position) < catchDistance)
        {
            FindObjectOfType<JumpscareManager>().TriggerJumpscare();
        }
    }
}
