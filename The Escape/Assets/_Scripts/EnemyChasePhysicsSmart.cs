using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyChasePhysicsSmart : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotationSpeed = 5f;
    public float catchDistance = 1.5f;
    public float obstacleAvoidanceRange = 1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (target == null) return;

        // Face the player at all times
        Vector3 lookDir = (target.position - transform.position);
        lookDir.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.fixedDeltaTime);

        // Check for obstacles using a raycast
        Vector3 moveDir = transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, moveDir, out hit, obstacleAvoidanceRange))
        {
            // If we hit a wall, try sliding to the side
            Vector3 avoidDir = Vector3.Cross(hit.normal, Vector3.up);
            moveDir = avoidDir.normalized;
        }

        // Move forward
        Vector3 newPos = rb.position + moveDir * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);

        // Check if close enough to catch player
        if (Vector3.Distance(transform.position, target.position) < catchDistance)
        {
            FindObjectOfType<JumpscareManager>().TriggerJumpscare();
        }
    }
}
