using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    protected Animator animator;
    protected Transform playerTransform;
    protected NavMeshAgent navMeshAgent;

    protected void Start() // �ڽ��� ������ �� �ֵ��� protected ���
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        // Player�� ã�� ���� ���� Transform ������Ʈ�� �����´�.

        
        ChangeState(new Run());                                                                                                                                    ChangeState(new Run());

    }

    public void ChangeState(IState state)
    {
        this.state = state;
    }



    protected virtual void Update()
    {
        switch(stateMachine)
        {
            case State.RUN:
                state.Action(animator, navMeshAgent);
                break;
            case State.DIE:
                state.Action(animator, navMeshAgent);
  
                break;
            case State.ATTACK:
                state.Action(animator, navMeshAgent);
                break;
        }

    }

    public void Death()
    {
        if (health <= 0)
        {
            ChangeState(new Die());
        }
    }


    public void Damage()
    {
        TakeHit(attack, playerTransform.gameObject);
        SoundManager.instance.PlayerSound(Sound.Hit);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        ChangeState(new Attack());
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        ChangeState(new Run());
    }

}
