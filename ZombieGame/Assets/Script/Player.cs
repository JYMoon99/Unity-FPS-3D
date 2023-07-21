using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float gravity = 100f;

    private float mouseX;
    private Vector3 direction;
    private CharacterController characterController;

    private void Awake()
    {
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

