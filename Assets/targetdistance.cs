using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetdistance : MonoBehaviour
{

    public targetmove targetmove;
    public GameObject scoreTextobject;
    //public Transform targetObject;

    public double[] round;

    private int [] checklist ;
    private bool shouldDisplayRoundValue = true;

    private float D_result = 20f;
    private float D_notangle = 90f;

    private int downnum = 0;

    public int totalscore = 0;
    public float totalaccuracy = 0;
    public float totalSensitivity = 0;
    public int totalbullet = 0;

    public float D_resultdistance = 0;
    public float D_targetdistance2 = 0;

    private float totaldistance = 0;
    private float totalpointdistance = 0;

    // 시작 시간 (5.00초)

    private int getscore = 0;

    //private bool shouldDisplayRoundValue = false;

    void Start()
    {
        //Cursor.visible = false;
        round = new double[] { 0, 0, 0 };
        StartCoroutine(DisplayRoundValueAfterDelay());
    }
    void Update()
    {


        if (targetmove.gameplay == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < targetmove.stage[targetmove.Level - 1]; i++)
                {
                    //Debug.Log(targetmove.stage[targetmove.Level - 1]);

                    // 시작 방향 벡터

                    Vector3 startVector = targetmove.carmeranowvector;
                    Debug.Log(startVector);
                    // 현재 위치
                    Vector3 currentPosition = transform.position;
                    // Debug.Log(currentPosition);
                    // 지정된 오브젝트 위치
                    Vector3 targetPosition = targetmove.targetVectors[i];
                    //Debug.Log(targetPosition);

                    // 현재 시야 방향 벡터
                    Vector3 forwardVector = transform.forward;

                    // 움직인거리계산
                    float notangle = Vector3.Angle(forwardVector, (targetPosition - currentPosition));

                    Debug.Log("각도 = "+ notangle);
                    float distance = Vector3.Distance(currentPosition, targetPosition);

                    //Debug.Log("시작위치와 목표거리값 " + distance);

                    float angle1 = Vector3.Angle(startVector, (targetPosition - currentPosition));

                    //Debug.Log("각도 " + angle1);

                    //Debug.Log("시작위치 거리값 " + distance * Mathf.Cos(angle1 * Mathf.Deg2Rad));

                    float startdistance = distance * Mathf.Cos(angle1 * Mathf.Deg2Rad);

                    //Debug.Log("초기위치와 목표 거리값 " + startdistance * Mathf.Tan(angle1 * Mathf.Deg2Rad));

                    float targetdistance2 = startdistance * Mathf.Tan(angle1 * Mathf.Deg2Rad);

                    //Debug.Log(targetdistance2);
                    float angle2 = Vector3.Angle(startVector, forwardVector);

                    //Debug.Log("초기위치와 사격한거리값 " + startdistance * Mathf.Tan(angle2 * Mathf.Deg2Rad));

                    float resultdistance = startdistance * Mathf.Tan(angle2 * Mathf.Deg2Rad);

                    //Debug.Log(resultdistance);

                    /*if ((resultdistance - targetdistance) >= 0)
                    {
                        Debug.Log("거리차이는 " + (resultdistance - targetdistance) + "로 감도가 빠름니다. ");
                    }
                    else
                    {
                        Debug.Log("거리차이는 " + (resultdistance - targetdistance) + "로 감도가 느립니다. ");
                    }*/
                    //Debug.Log("Mathf.Abs(resultdistance - targetdistance2)" + Mathf.Abs(resultdistance - targetdistance2));

                    if (D_notangle > notangle )
                    {
                        D_notangle = notangle;
                        D_result = (resultdistance - targetdistance2);

                        //Debug.Log("D_result" + D_result);


                        downnum = i;
                        D_resultdistance = resultdistance;
                        D_targetdistance2 = targetdistance2;

                        //Debug.Log(Mathf.Abs(D_result));

                    }




                }


                totaldistance += D_resultdistance;
                //Debug.Log(totaldistance);
                totalpointdistance += D_targetdistance2;
                //Debug.Log(totalpointdistance);

                if (Mathf.Abs(D_result) > 2.6)
                {
                    totalaccuracy += 2.6f;
                }
                else
                {
                    totalaccuracy += (Mathf.Abs(D_result));
                }

                if (Mathf.Abs(D_result) < 0.3f)
                {
                    getscore = 10;
                }
                else
                {

                    getscore = 5 + (int)((1.3f - Mathf.Abs(D_result)) / 0.2f);

                    if (getscore <= 0)
                    {
                        getscore = 0;
                    }
                }
                totalbullet++;
                totalscore += getscore;
                targetmove.childAnimators[targetmove.selectedIndices[downnum]].SetTrigger("changedown");
                TakeDamage(getscore, targetmove.targetVectors[downnum]);
                //Debug.Log("넘어간 타겟 번호" + targetmove.selectedIndices[downnum]);
                round[1] = round[1] + (D_result);


                D_result = 100;
                D_notangle = 100;
                totalSensitivity = totalpointdistance / totaldistance;
                //Debug.Log(totalSensitivity);


                targetmove.targetVectors[downnum] = new Vector3(200f, 200f, 200f);



            }
        }

        
        if (Input.GetKeyDown(KeyCode.P))
        {
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

            // Reset the flag after displaying the value
            shouldDisplayRoundValue = false;
        }
    }

    public void TakeDamage(int damage , Vector3 getposition)
    {
        GameObject hudText = Instantiate(scoreTextobject); // 생성할 텍스트 오브젝트
        getposition.y += 0.5f; // y 값을 0.5만큼 증가시킴
        getposition.z += 0.5f;
        hudText.transform.position = getposition; // 수정된 위치를 적용

        hudText.GetComponent<scoreText>().score = damage; // 데미지 전달

    }
}
