using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;


public class Player : Entity
{
    [SerializeField] float speed = 8.0f;
    [SerializeField] float gravity = 100f;
    [SerializeField] ParticleSystem particle;


    private Rifle rifle;
    private float mouseX;
    private Vector3 direction;
    private Animator animator;
    private CharacterController characterController;

    private void Awake()
    {
        health = 100;
        rifle = GetComponent<Rifle>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        // ���콺 Ŀ�� ��Ȱ��ȭ
        Cursor.visible = false;

        // ���콺 Ŀ�� ��� (ȭ�� ������ �� ������)
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && rifle.magazine > 0)
        {
            particle.Play();
            rifle.Launch();

            if (rifle.magazine <= 0)
            {
                StartCoroutine(rifle.Reload(animator));
            }
        }




        Movement(); // ĳ���� �̵� ���� �Լ�
        Rotate(); // ���콺 ȸ�� �Լ�
    }


    #region ĳ���� �̵� ���� �Լ�
    // ĳ���� �̵� ���� �Լ�
    private void Movement()
    {

        // x ���� �� ����
        direction.x = Input.GetAxisRaw("Horizontal");

        // y ���� �� ����
        direction.z = Input.GetAxisRaw("Vertical");

        // ������ ����ȭ
        direction.Normalize();

        // �߷� ����
        direction.y -= Time.deltaTime * gravity;

        characterController.Move(transform.TransformDirection(direction) * speed * Time.deltaTime);
  

    }

    #endregion

    #region ���콺 ȸ�� �Լ�
    void Rotate()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speed * 5;

        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    #endregion



}

