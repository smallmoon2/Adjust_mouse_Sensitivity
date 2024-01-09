using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twodistanceval : MonoBehaviour
{
    public cuberamdom cuberamdom;
    public Transform targetObject;

    public double[] round;

    private bool shouldDisplayRoundValue = true;

    //private bool shouldDisplayRoundValue = false;

    void Start()
    {
        Cursor.visible = false;
        round = new double[] { 0, 0, 0 };
        StartCoroutine(DisplayRoundValueAfterDelay());
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 시작 방향 벡터

            Vector3 startVector = cuberamdom.nowvector;
            Debug.Log(startVector);
            // 현재 위치
            Vector3 currentPosition = transform.position;
            Debug.Log(currentPosition);
            // 지정된 오브젝트 위치
            Vector3 targetPosition = targetObject.position;
            Debug.Log(targetPosition);

            // 현재 시야 방향 벡터
            Vector3 forwardVector = transform.forward;

            // 움직인거리계산

            float distance = Vector3.Distance(currentPosition, targetPosition);

            //Debug.Log("시작위치와 목표거리값 " + distance);

            float angle1 = Vector3.Angle(startVector, (targetPosition - currentPosition));

            //Debug.Log("각도 " + angle1);

            //Debug.Log("시작위치 거리값 " + distance * Mathf.Cos(angle1 * Mathf.Deg2Rad));

            float startdistance = distance * Mathf.Cos(angle1 * Mathf.Deg2Rad);

            //Debug.Log("초기위치와 목표 거리값 " + startdistance * Mathf.Tan(angle1 * Mathf.Deg2Rad));

            float targetdistance = startdistance * Mathf.Tan(angle1 * Mathf.Deg2Rad);

            float angle2 = Vector3.Angle(startVector, forwardVector);

            //Debug.Log("초기위치와 사격한거리값 " + startdistance * Mathf.Tan(angle2 * Mathf.Deg2Rad));

            float resultdistance = startdistance * Mathf.Tan(angle2 * Mathf.Deg2Rad);

            Debug.Log("resultdistance " + resultdistance );
            Debug.Log("targetdistance " + targetdistance);
            if ((resultdistance - targetdistance) >= 0) {

                Debug.Log("거리차이는 " + (resultdistance - targetdistance) + "로 감도가 빠름니다. ");
            }
            else {

                Debug.Log("거리차이는 " + (resultdistance - targetdistance) + "로 감도가 느립니다. ");
            }
            

            round[1] = round[1] + (resultdistance - targetdistance);





        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("눌림");
            Cursor.visible = true;
        }

    
    }
    IEnumerator DisplayRoundValueAfterDelay()
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(10.0f);

        // Check if we should display the value
        if (shouldDisplayRoundValue)
        {
            Debug.Log("round[1] after 10 seconds: " + round[1]);

            // Reset the flag after displaying the value
            shouldDisplayRoundValue = false;
        }
    }
}
