using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_3D_test: MonoBehaviour
{
    public TR_3D_target TR_3D_target;
    public GameObject scoreTextobject;
    //public Transform targetObject;

    public double[] round;

    private int[] checklist;
    private bool shouldDisplayRoundValue = true;

    private float D_result = 20f;
    private float D_notangle = 90f;
    public int downnum = 0;

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




        if (TR_3D_target.gameplayer == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < 5; i++)
                {

                    Vector3 startVector = TR_3D_target.carmeranowvector;
                    Vector3 currentPosition = transform.position;
                    Vector3 targetPosition = TR_3D_target.targetVectors[i];



                    Vector3 forwardVector = transform.forward;



                    float distance = Vector3.Distance(currentPosition, targetPosition);


                    float notangle = Vector3.Angle(forwardVector, (targetPosition - currentPosition));
                    float angle1 = Vector3.Angle(startVector, (targetPosition - currentPosition));


                    float startdistance = distance * Mathf.Cos(angle1 * Mathf.Deg2Rad);


                    float targetdistance2 = startdistance * Mathf.Tan(angle1 * Mathf.Deg2Rad);


                    float angle2 = Vector3.Angle(startVector, forwardVector);

                    float resultdistance = startdistance * Mathf.Tan(angle2 * Mathf.Deg2Rad);

                    if (D_notangle > notangle)
                    {
                        D_notangle = notangle;
                        D_result = (resultdistance - targetdistance2);

                        downnum = i;
                        D_resultdistance = resultdistance;
                        D_targetdistance2 = targetdistance2;

                    }




                }


                totaldistance += D_resultdistance;

                totalpointdistance += D_targetdistance2;


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
                TR_3D_target.childAnimators[TR_3D_target.selectedIndices[downnum]].SetTrigger("changedown");
                TakeDamage(getscore, TR_3D_target.targetVectors[downnum]);
                //Debug.Log("넘어간 타겟 번호" + targetmove.selectedIndices[downnum]);
                round[1] = round[1] + (D_result);

                Debug.Log("최종은 " + D_result + "입니다.");
                D_result = 100;
                D_notangle = 90;
                if (totaldistance != 0)
                {
                    totalSensitivity = totalpointdistance / totaldistance;

                }
                TR_3D_target.targetVectors[downnum] = new Vector3(200f, 200f, 200f);
                TR_3D_target.onetargetup();

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

    public void TakeDamage(int damage, Vector3 getposition)
    {
        GameObject hudText = Instantiate(scoreTextobject); // 생성할 텍스트 오브젝트
        getposition.y += 0.5f; // y 값을 0.5만큼 증가시킴
        getposition.z += 0.5f;
        hudText.transform.position = getposition; // 수정된 위치를 적용

        hudText.GetComponent<scoreText>().score = damage; // 데미지 전달

    }
}
