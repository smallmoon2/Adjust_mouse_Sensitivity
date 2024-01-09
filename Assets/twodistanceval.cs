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
            // ���� ���� ����

            Vector3 startVector = cuberamdom.nowvector;
            Debug.Log(startVector);
            // ���� ��ġ
            Vector3 currentPosition = transform.position;
            Debug.Log(currentPosition);
            // ������ ������Ʈ ��ġ
            Vector3 targetPosition = targetObject.position;
            Debug.Log(targetPosition);

            // ���� �þ� ���� ����
            Vector3 forwardVector = transform.forward;

            // �����ΰŸ����

            float distance = Vector3.Distance(currentPosition, targetPosition);

            //Debug.Log("������ġ�� ��ǥ�Ÿ��� " + distance);

            float angle1 = Vector3.Angle(startVector, (targetPosition - currentPosition));

            //Debug.Log("���� " + angle1);

            //Debug.Log("������ġ �Ÿ��� " + distance * Mathf.Cos(angle1 * Mathf.Deg2Rad));

            float startdistance = distance * Mathf.Cos(angle1 * Mathf.Deg2Rad);

            //Debug.Log("�ʱ���ġ�� ��ǥ �Ÿ��� " + startdistance * Mathf.Tan(angle1 * Mathf.Deg2Rad));

            float targetdistance = startdistance * Mathf.Tan(angle1 * Mathf.Deg2Rad);

            float angle2 = Vector3.Angle(startVector, forwardVector);

            //Debug.Log("�ʱ���ġ�� ����ѰŸ��� " + startdistance * Mathf.Tan(angle2 * Mathf.Deg2Rad));

            float resultdistance = startdistance * Mathf.Tan(angle2 * Mathf.Deg2Rad);

            Debug.Log("resultdistance " + resultdistance );
            Debug.Log("targetdistance " + targetdistance);
            if ((resultdistance - targetdistance) >= 0) {

                Debug.Log("�Ÿ����̴� " + (resultdistance - targetdistance) + "�� ������ �����ϴ�. ");
            }
            else {

                Debug.Log("�Ÿ����̴� " + (resultdistance - targetdistance) + "�� ������ �����ϴ�. ");
            }
            

            round[1] = round[1] + (resultdistance - targetdistance);





        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("����");
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
