using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseNav : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public float catchDistance = 1.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target == null) return;

        // Continuously update the destination to the player's position
        agent.SetDestination(target.position);

        // Check for catch
        if (Vector3.Distance(transform.position, target.position) < catchDistance)
        {
            FindObjectOfType<JumpscareManager>().TriggerJumpscare();
        }
    }
}
