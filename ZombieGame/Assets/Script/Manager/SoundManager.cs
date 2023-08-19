using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Sound
{
    Shot,
    Reload,
    Hit,
    Jump,

}

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmAudio;
    [SerializeField] AudioSource playerAudio;

    [SerializeField] AudioClip[] playerCilp;

    public static SoundManager instance = null;

    private void Awake()
    {
        // �̱���
        if(instance == null) 
        {
            instance = this; // �ڽ��� Ŭ���� �޸� �ּҸ� �Ҵ�
        }
        else
        {
            Destroy(instance); // static�� �����̱� ������ �ڱ��ڽ��� �޸𸮰� �ö󰡾� ����� �Ǵ� ���, 2�� �̻� �ö󰡸� �ȵǱ� ������ �ı�
        }
    }

    public void PlayerSound(Sound sound)
    {
        playerAudio.PlayOneShot(playerCilp[(int)sound]);

    }
}
