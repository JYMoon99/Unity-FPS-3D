using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Run : MonoBehaviour, IState
{
    public void Action(Zombie zombie)
    {
        zombie.animator.SetBool("Attack", false);

        zombie.navMeshAgent.speed = 1.5f;

        Transform playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        zombie.navMeshAgent.SetDestination(playerTransform.position);
    }
}
