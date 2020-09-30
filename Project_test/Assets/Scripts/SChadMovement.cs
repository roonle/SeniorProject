using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

public class SChadMovement : MonoBehaviour
{
    public Transform[] points;
    private int desPoint = 0;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GotoNextPoint();
    }

    private void GotoNextPoint()
    {
        if(points.Length > 0)
        {

            agent.destination = points[desPoint].position;
            desPoint = (desPoint + 1) % points.Length;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
