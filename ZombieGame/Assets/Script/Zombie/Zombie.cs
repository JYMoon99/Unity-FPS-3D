using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Zombie : Entity
{
    protected float attack;

    protected Animator animator;
    protected Transform playerTransform;
    protected NavMeshAgent navMeshAgent;

    protected void Start() // �ڽ��� ������ �� �ֵ��� protected ���
    {
        animator = GetComponent<Animator>();     
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        // Player�� ã�� ���� ���� Transform ������Ʈ�� �����´�.
    }

    public void Damage()
    {
        TakeHit(attack, gameObject);
        Debug.Log(attack);
    }


    protected abstract void Movement();


}
