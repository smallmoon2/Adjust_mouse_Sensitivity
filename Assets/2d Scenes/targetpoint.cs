using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetpoint : MonoBehaviour
{
    public float percent = 1;
    Camera Camera;
    public GameObject start;
    public GameObject point_2d;
    public GameObject nullpoint;

    public GameObject[] pointlist = new GameObject[4];
    private int round = 1;
    public int pointnum = 0;
    public GameObject[] targets = new GameObject[3];
    public float totaldistance = 0;
    public float totalpointdistance = 0;
    public GameObject[] stagetargets = new GameObject[3];

    public float XRange = 6.5f;  // 최소 생성 범위
    public float YRange = 4f;

    public float minXRange = 2.5f;  // 최소 생성 범위
    public float minYRange = 1.5f;

    public bool gameover_2D = true;
    public int count = 0;

    private Vector2 SensValue;
    //UI 
    public GameObject UIview2D;
    public float D_result2D;
    private int getscore2D;
    public int totalscore2D;
    public int totalcheck = 0;
    public float totalaccuracy2D = 0;

    private float nowtarget = 200;
    void Start()
    {
        //restart();
        round = startUI.level;
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (gameover_2D == true)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.lockState = CursorLockMode.Locked;
                Invoke("mouseNone", 0.1f);
                Cursor.visible = false;
            }


            if (Input.GetKeyDown(KeyCode.L))
            {

                Cursor.visible = true;

            }


            round = startUI.level;
            // 마우스 왼쪽 버튼을 클릭했을 때
            if (Input.GetMouseButtonDown(0))
            {
                //Invoke("mouseNone", 0.1f);
                //mouseNone();
                //Cursor.visible = false;
                Vector2 mousePos = Input.mousePosition;
                mousePos = Camera.ScreenToWorldPoint(mousePos);

                if (count ==0)
                {
                    pointlist[count] = Instantiate(point_2d, new Vector3(0.11f,0.11f, 0f), Quaternion.identity);
                }
                else
                {
                    pointlist[count] = Instantiate(nullpoint, new Vector3(mousePos.x + 0.15f, mousePos.y - 0.15f, 0f), Quaternion.identity);
                }
                // point_2d 오브젝트를 mousePos 위치에 생성하고 pointlist의 자식으로 설정합니다.



                //Debug.Log("Mouse Position (2D): " + mousePos);

                for (int i = 0; i < (round + 2) / 3; i++)
                {
                    if (stagetargets[i] != null)
                    {


                        if (nowtarget > Vector3.Distance(stagetargets[i].transform.position, mousePos))
                        {


                            nowtarget = Vector3.Distance(stagetargets[i].transform.position, mousePos);
                            pointnum = i;
                        }
                    }


                }

                if (start.activeSelf == false)
                {

                    Vector3 adjustedTargetPosition = stagetargets[pointnum].transform.position + new Vector3(SensValue.x, SensValue.y, 0);


                    float targetdistance = Vector3.Distance(adjustedTargetPosition, pointlist[count - 1].transform.position);


                    //포인트까지 클릭 지점
                    float pointdistance = Vector3.Distance(pointlist[count].transform.position, pointlist[count - 1].transform.position);
                    //
                    //Debug.Log(pointdistance);

                    if (pointdistance - targetdistance > 0)
                    {
                        //Debug.Log(pointdistance - targetdistance + "만큼 감도가 빠릅니다.");
                    }
                    else
                    {
                        //Debug.Log(targetdistance - pointdistance + "만큼 감도가 느립니다.");
                    }

                    totaldistance = totaldistance + targetdistance;
                    totalpointdistance = totalpointdistance + pointdistance;


                    D_result2D = pointdistance - targetdistance;
                    Debug.Log(D_result2D);
                    if (Mathf.Abs(D_result2D) > 2)
                    {
                        
                        totalaccuracy2D += 2f;
                        Debug.Log(totalaccuracy2D);
                    }
                    else
                    {

                        totalaccuracy2D += (Mathf.Abs(D_result2D));
                        Debug.Log(totalaccuracy2D);
                    }

                    if (Mathf.Abs(D_result2D) < 0.15f)
                    {
                        getscore2D = 10;
                    }
                    else
                    {

                        getscore2D = 5 + (int)((0.65f - Mathf.Abs(D_result2D)) / 0.1f);

                        if (getscore2D <= 0)
                        {
                            getscore2D = 0;
                        }
                    }
                    //Debug.Log("총 보정 감도" + totaldistance / totalpointdistance);

                    totalcheck++;

                }

                //pointnum++;
                count++;


                totalscore2D += getscore2D;

                if (pointnum < 3 && stagetargets[pointnum] != null)
                {
                    Vector3 newPosition = stagetargets[pointnum].transform.position;
                    SensValue += new Vector2(mousePos.x - newPosition.x, mousePos.y - newPosition.y);
                    Destroy(stagetargets[pointnum]);
                }



                nowtarget = 200;

            }

            if (stagetargets[0] == null && stagetargets[1] == null && stagetargets[2] == null && round < 10 && start.activeSelf == false)
            {

                //Debug.Log("삭제");
                //Cursor.visible = true;


                if (startUI.level == 9)
                {
                    gameover_2D = false;
                    UIview2D.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    return;
                }
                start.SetActive(true);

                count = 0;



                for (int i = 0; i < pointlist.Length; i++)
                {
                    if (pointlist[i] != null)
                    {
                        Destroy(pointlist[i]);
                        pointlist[i] = null; // 삭제된 항목을 null로 설정하여 배열에서 제거
                    }

                }

                mousereset();

            }
        }
        

    }

    public void  restart()
    {
        pointnum = 0;

        start.SetActive(false);

        //Debug.Log("시작");
        round = startUI.level;
        for (int i = 0; i < (round + 2) / 3; i++)
        {
            // 이전 타겟이 있으면 삭제


            if (stagetargets[i] != null)
            {
                Destroy(stagetargets[i]);
            }
            // 랜덤한 X와 Y 좌표 생성
            bool validPosition = false;
            Vector3 spawnPosition = Vector3.zero;

            while (!validPosition)
            {
                // Generate new random X and Y coordinates
                float randomX = Random.Range(-XRange, XRange);
                float randomY = Random.Range(-YRange, YRange);

                validPosition = true;

                if (randomX < minXRange && XRange > -minXRange && randomY < minYRange && randomY > -minYRange)
                {
                    
                    validPosition = false;
                }
                // Calculate spawn position
                spawnPosition = new Vector3(randomX, randomY, 0f);

                // Check if the new position is at least 2 units away from existing positions
                
                for (int j = 0; j < i; j++)
                {
                    //Debug.Log(Vector3.Distance(spawnPosition, stagetargets[j].transform.position));
                    if (Vector3.Distance(spawnPosition, stagetargets[j].transform.position) < 2f)
                    {
                        // The new position is too close to an existing position, generate a new position
                        validPosition = false;
                        break;
                    }
                }
            }
            stagetargets[i] = Instantiate(targets[i], spawnPosition, Quaternion.identity);

            SensValue = new Vector2(0f, 0f);
        }

    }
    void mouseLocked()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void mouseNone()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void mousereset()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        Invoke("mouseNone", 0.1f);
        Cursor.visible = false;
    }
}
