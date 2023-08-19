using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Run : IState
{
    public void Action(Animator animator, NavMeshAgent navMeshAgent)
    {
        animator.SetBool("Attack", false);

        navMeshAgent.speed = 1.5f;

        Transform playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        navMeshAgent.SetDestination(playerTransform.position);
    }
}
