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

            // 현재 위치
            Vector3 currentPosition = transform.position;

            // 지정된 오브젝트 위치
            Vector3 targetPosition = targetObject.position;

            // 시야 방향 벡터
            Vector3 forwardVector = transform.forward;

            // 움직인거리계산

            float distance = Vector3.Distance(currentPosition, targetPosition);

            // 내적 계산
            float dot2 = Vector3.Dot((targetPosition - currentPosition).normalized, forwardVector);

            // 각도 계산
            float angle = Vector3.Angle(forwardVector, (targetPosition - currentPosition));

            // 거리와 각도 값 출력
            Debug.Log("Distance * sin(angle): " + distance * Mathf.Tan(angle * Mathf.Deg2Rad));
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("눌림");
            Cursor.visible = true;
        }

    }
}

