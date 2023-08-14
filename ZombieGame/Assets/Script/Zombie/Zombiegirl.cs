using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombiegirl : Zombie
{
    protected override void Movement()
    {
        navMeshAgent.SetDestination(playerTransform.position);
    }

    new void Start()
    {
        base.Start(); // base : 부모 클래스

        health = 50;
        attack = 20;

    }

    private void Update()
    {
        Movement();
    }


}
