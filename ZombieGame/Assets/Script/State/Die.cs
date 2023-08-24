using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Die : MonoBehaviour, IState
{
    public void Action(Zombie zombie)
    {

        zombie.animator.Play("Die");
        zombie.navMeshAgent.speed = 0;

        // �ִϸ����� ��Ʈ�ѷ����� ���� �ִϸ������� ������ �̸��� ��Die�� �� �� 
        if (zombie.animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            // ���� �ִϸ��̼��� ���൵�� 1���� ũ�ų� ���ٸ� Destroy
            if (zombie.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                zombie.navMeshAgent.speed = 0;
                Destroy(zombie.animator.gameObject);
            }
        }


    }
}
