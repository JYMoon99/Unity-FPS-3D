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

        // 애니메이터 컨트롤러에서 현재 애니메이터의 상태의 이름이 “Die” 일 때 
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            // 현재 애니메이션의 진행도가 1보다 크거나 같다면 Destroy
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                Destroy(animator.gameObject);
            }
        }


    }
}
