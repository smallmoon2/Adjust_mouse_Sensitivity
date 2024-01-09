using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecam : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 5f;
    public float rotationSpeed = 0.1f;
    float mx = 0;
    float my = 0;
    void Update()
    {
        // ���콺 �Է����� ȭ�� ȸ��
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        mx += h * rotationSpeed;
        my += v * rotationSpeed;

        if (my >= 90)
        {
            my = 90;
        }
        else if (my <= -90)
        {
            my = -90;
        }
        transform.eulerAngles = new Vector3(-my, mx, 0);

        // Ű���� �Է����� �̵�
        h = Input.GetAxis("Horizontal");        // ������
        v = Input.GetAxis("Vertical");          // ������

        // Point 2.
        Vector3 movement = new Vector3(h, 0, v) * movementSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0); // ���� Y ȸ���� ����
        movement = rotation * movement; // �̵� ������ ���� ȸ�������� ��ȯ
        transform.Translate(movement, Space.World);
    }


}
