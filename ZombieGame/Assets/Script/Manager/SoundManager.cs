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
        // 싱글톤
        if(instance == null) 
        {
            instance = this; // 자신의 클래스 메모리 주소를 할당
        }
        else
        {
            Destroy(instance); // static은 정적이기 때문에 자기자신의 메모리가 올라가야 사용이 되는 기법, 2개 이상 올라가면 안되기 때문에 파괴
        }
    }

    public void PlayerSound(Sound sound)
    {
        playerAudio.PlayOneShot(playerCilp[(int)sound]);

    }
}
