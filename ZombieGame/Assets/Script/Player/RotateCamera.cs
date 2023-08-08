using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    private float mouseY;
    void Update()
    {
        mouseY += Input.GetAxisRaw("Mouse Y") * speed;

        mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f);

        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);

    }
}
