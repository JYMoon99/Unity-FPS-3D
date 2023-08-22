using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour 
{
    private float attack;
    public int magazine;
    private RaycastHit hit;

    public Rifle() 
    {
        magazine = 15;
        attack = 25;
    }



    public void Launch()
    {
        SoundManager.instance.PlayerSound(Sound.Shot);

        // 화면의 중앙 좌표 (Cross Hair를 기준으로 Raycast를 연산한다.)
        Ray ray = Camera.main.ViewportPointToRay(Vector2.one * 0.5f);

            // 공격 사거리 안에 부딪히는 오브젝트가 있으면 target은 광선에 부딪힌 위치로 설정
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                IDamageable clone = hit.collider.GetComponent<IDamageable>();

                if(clone != null) 
                {
                    clone.TakeHit(attack, hit.collider.gameObject);
                    hit.collider.GetComponent<Zombie>().Death();
                }
            }

            magazine--;

    }

    public IEnumerator Reload(Animator animator)
    {
        animator.Play("Character_Reload");
        SoundManager.instance.PlayerSound(Sound.Reload);
        

        yield return new WaitForSeconds(0.01f);

        // 애니메이션 시간
        float animationTime = animator.GetCurrentAnimatorStateInfo(0).length; 

        yield return new WaitForSeconds(animationTime);

        magazine = 15;
    }
}
