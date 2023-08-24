using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour, IState
{
    public void Action(Zombie zombie)
    {
        zombie.GetComponent<NavMeshAgent>().speed = 0;

        zombie.animator.SetBool("Attack", true);

    }

}
