using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteZombie : Zombie
{
    protected override void Movement()
    {
        navMeshAgent.SetDestination(playerTransform.position);
    }

    new void Start()
    {
        base.Start(); // base : 부모 클래스

        health = 120;
        attack = 7;

    }

    private void Update()
    {
        Movement();
    }




}

