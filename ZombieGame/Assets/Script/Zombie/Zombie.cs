using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    RUN,
    ATTACK,
    DIE
}


public abstract class Zombie : Entity
{
    private IState state;
    private State stateMachine;

    protected float attack;

    public Animator animator;
    public Transform targetPosition;
    public NavMeshAgent navMeshAgent;

    protected void Start() // �ڽ��� ������ �� �ֵ��� protected ���
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetPosition = GameObject.Find("Player").GetComponent<Transform>();
        // Player�� ã�� ���� ���� Transform ������Ʈ�� �����´�.


        StateMachine(new Run()); 
    }

    public void StateMachine(IState state)
    {
        this.state = state;
    }



    protected virtual void Update()
    {
        state.Action(this);
    }

    public void Damage()
    {
        TakeHit(attack, targetPosition.gameObject);
        StartCoroutine(targetPosition.GetComponent<Player>().Shake(0.5f, 0.25f));

        SoundManager.instance.PlayerSound(Sound.Hit);
    }

    public void Death()
    {
        if (health <= 0)
        {
            StateMachine(new Die());
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {

        if (health > 0)
        {
            StateMachine(new Attack());
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (health > 0)
        {
            StateMachine(new Run());
        }
    }

}
