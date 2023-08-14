using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarZombie : Zombie
{
    protected override void Movement()
    {
        navMeshAgent.SetDestination(playerTransform.position);
        // SetDestination : ������ ��η� �ڵ� �̵��ϴ� �Լ�
    }

    new void Start()
    {
        base.Start(); // base : �θ� Ŭ����

        health = 100;
        attack = 5;
      
    }

    private void Update()
    {
        Movement();
    }

}
