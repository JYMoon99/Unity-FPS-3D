using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarZombie : Zombie
{
    protected override void Movement()
    {
        navMeshAgent.SetDestination(playerTransform.position);
        // SetDestination : 최적의 경로로 자동 이동하는 함수
    }

    new void Start()
    {
        base.Start(); // base : 부모 클래스

        health = 100;
        attack = 5;
      
    }

    private void Update()
    {
        Movement();
    }

}
