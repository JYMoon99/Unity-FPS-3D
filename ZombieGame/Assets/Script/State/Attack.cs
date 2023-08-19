using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : IState
{
    public void Action(Animator animator, NavMeshAgent navMeshAgent)
    {
        navMeshAgent.speed = 0;

        animator.SetBool("Attack", true);

    }

}
