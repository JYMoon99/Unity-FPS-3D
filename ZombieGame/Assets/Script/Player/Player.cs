using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rifle))]
public class Player : Entity
{
    [SerializeField] float speed = 8.0f;
    [SerializeField] float gravity = 100f;
    [SerializeField] ParticleSystem particle;
    [SerializeField] ParticleSystem fragments;


    private Rifle rifle;
    private float mouseX;

    private Vector3 direction;
    private Vector3 cameraDirection;

    private Animator animator;
    private CharacterController characterController;

    private void Awake()
    {
        health = 100;
        rifle = GetComponent<Rifle>();
        animator = GetComponent<Animator>();

        cameraDirection = Camera.main.transform.localPosition; // 메인 카메라를 찾는다
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        // 마우스 커서 비활성화
        Cursor.visible = false;

        // 마우스 커서 잠금 (화면 밖으로 안 나가게)
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && rifle.magazine > 0)
        {
            particle.Play();
            rifle.Launch(fragments);

            if (rifle.magazine <= 0)
            {
                StartCoroutine(rifle.Reload(animator));
            }
        }




        Movement(); // 캐릭터 이동 관련 함수
        Rotate(); // 마우스 회전 함수
    }


    #region 캐릭터 이동 관련 함수
    // 캐릭터 이동 관련 함수
    private void Movement()
    {

        // x 방향 값 설정
        direction.x = Input.GetAxisRaw("Horizontal");

        // y 방향 값 설정
        direction.z = Input.GetAxisRaw("Vertical");

        // 벡터의 정규화
        direction.Normalize();

        // 중력 적용
        direction.y -= Time.deltaTime * gravity;

        characterController.Move(transform.TransformDirection(direction) * speed * Time.deltaTime);
  

    }

    #endregion

    #region 마우스 회전 함수
    void Rotate()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speed * 5;

        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    #endregion


    #region 캐릭터 데미지 효과

    public IEnumerator Shake(float amount, float duration)
    {
        while(0 < duration) 
        {
            Camera.main.transform.localPosition = (Vector3)Random.insideUnitCircle * amount + cameraDirection;

            duration -= Time.deltaTime;

            yield return null;

            
        }

        Camera.main.transform.localPosition = cameraDirection;
    }

    #endregion
}

