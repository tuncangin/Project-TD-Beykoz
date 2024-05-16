using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class AgentFollower : MonoBehaviour
{
    private NavMeshAgent myAgent;
    public Transform objectToFollow;
    
    
    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        objectToFollow = GameObject.FindWithTag("TargetPosition").transform;
    }

    private void Update()
    {
        myAgent.SetDestination(objectToFollow.position);
    }
}
