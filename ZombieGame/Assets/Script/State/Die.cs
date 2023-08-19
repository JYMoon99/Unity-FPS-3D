using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Die : MonoBehaviour, IState
{


    public void Action(Animator animator, NavMeshAgent navMeshAgent)
    {

        animator.Play("Die");
        navMeshAgent.speed = 0;

        // �ִϸ����� ��Ʈ�ѷ����� ���� �ִϸ������� ������ �̸��� ��Die�� �� �� 
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            // ���� �ִϸ��̼��� ���൵�� 1���� ũ�ų� ���ٸ� Destroy
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                Destroy(animator.gameObject);
            }
        }


    }
}
