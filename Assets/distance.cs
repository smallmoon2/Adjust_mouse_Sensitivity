using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distance : MonoBehaviour
{

    public Transform targetObject;
    void Start()
    {
        Cursor.visible = false;
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // ���� ��ġ
            Vector3 currentPosition = transform.position;

            // ������ ������Ʈ ��ġ
            Vector3 targetPosition = targetObject.position;

            // �þ� ���� ����
            Vector3 forwardVector = transform.forward;

            // �����ΰŸ����

            float distance = Vector3.Distance(currentPosition, targetPosition);

            // ���� ���
            float dot2 = Vector3.Dot((targetPosition - currentPosition).normalized, forwardVector);

            // ���� ���
            float angle = Vector3.Angle(forwardVector, (targetPosition - currentPosition));

            // �Ÿ��� ���� �� ���
            Debug.Log("Distance * sin(angle): " + distance * Mathf.Tan(angle * Mathf.Deg2Rad));
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("����");
            Cursor.visible = true;
        }

    }
}

