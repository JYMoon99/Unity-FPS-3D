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
        base.Start(); // base : �θ� Ŭ����

        health = 50;
        attack = 20;

    }

    private void Update()
    {
        Movement();
    }


}
