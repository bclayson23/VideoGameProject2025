using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCatchTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            FindObjectOfType<JumpscareManager>().TriggerJumpscare();

            var nav = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
            if (nav)
            {
                nav.isStopped = true;
                nav.enabled = false; // <-- freezes enemy completely
            }

            var chase = GetComponentInParent<EnemyChaseNav>();
            if (chase) chase.enabled = false;
        }
    }
}