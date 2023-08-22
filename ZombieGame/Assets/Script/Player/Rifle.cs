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

        // ȭ���� �߾� ��ǥ (Cross Hair�� �������� Raycast�� �����Ѵ�.)
        Ray ray = Camera.main.ViewportPointToRay(Vector2.one * 0.5f);

            // ���� ��Ÿ� �ȿ� �ε����� ������Ʈ�� ������ target�� ������ �ε��� ��ġ�� ����
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

        // �ִϸ��̼� �ð�
        float animationTime = animator.GetCurrentAnimatorStateInfo(0).length; 

        yield return new WaitForSeconds(animationTime);

        magazine = 15;
    }
}
