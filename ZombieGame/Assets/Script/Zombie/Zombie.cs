using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Zombie : MonoBehaviour
{
    protected float hp;
    protected float attack;

    protected Animator animator;
    protected Transform playerTransform;
    protected NavMeshAgent navMeshAgent;

    protected void Start() // 자식이 접근할 수 있도록 protected 사용
    {
        animator = GetComponent<Animator>();     
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        // Player를 찾은 다음 그의 Transform 컴포넌트를 가져온다.
    }

    protected abstract void Movement();


}
