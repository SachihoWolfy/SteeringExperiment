using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wander : Seek
{
    // Radius for generating random target positions
    public float wanderRadius = 5f;

    // Time interval to pick a new random target
    public float wanderInterval = 2f;

    private float timeSinceLastWander = 0f;
    private Vector3 currentWanderTarget;

    protected override Vector3 getTargetPosition()
    {
        timeSinceLastWander += Time.deltaTime;
        if (timeSinceLastWander >= wanderInterval || Vector3.Distance(currentWanderTarget,character.transform.position) < 0.2f)
        {
            timeSinceLastWander = 0f;
            PickRandomWanderTarget();
        }

        return currentWanderTarget;
    }

    private void PickRandomWanderTarget()
    {
        // Generate a random direction on the XZ plane
        Vector2 randomDirection = Random.insideUnitCircle.normalized * wanderRadius;

        // Convert to 3D and set the current wander target
        currentWanderTarget = target.transform.position + new Vector3(randomDirection.x, 0, randomDirection.y);
    }

    private void OnDrawGizmos()
    {
        // Draw the wander radius in the editor for visualization
        Gizmos.color = Color.green;
        if (character != null)
        {
            Gizmos.DrawWireSphere(character.transform.position, wanderRadius);
        }

        // Draw the current wander target
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(currentWanderTarget, 0.2f);
    }
}

