using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    private Transform target;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            faceTarget();
        }
    }

    public void moveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void followTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;
        
        target = newTarget.interactionTransform;
    }

    public void stopFollowingTarget()
    {
        agent.updateRotation = true;
        agent.stoppingDistance = 0f;
        target = null;
    }

    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookrotation , Time.deltaTime * 5);

    }
}
