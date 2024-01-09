using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_2D_test : MonoBehaviour
{

    Camera Camera;

    private bool gameover = true;
    public GameObject targetPrefab;
    public GameObject start;
    public GameObject EndUi;
    public float XRange = 6.5f;
    public float YRange = 4f;
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 0.5f;
    public int totalmousedown = 0;

    public Vector2 oldmouse;
    public int totalscore = 0;
    public float currentTime = 20.0f;
    private float nowtarget = 200;
    private int num = 0;

    private int pouintnum = 0;
    public float targetdistance;

    public GameObject[] pointlist = new GameObject[10];

    void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        if (!gameover)
        {
            //InvokeRepeating("SpawnTarget", 0f, Random.Range(minSpawnInterval, maxSpawnInterval));
        }
    }

    void Update()
    {


        if (gameover == false)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0.0f)
            {
                currentTime = 0.0f; // 시간이 0보다 작아지면 0으로 고정
                gameover = true;
                EndUi.SetActive(true);
            }

            // 게임 중일 때의 로직 추가
            CheckForClick();
        }
    }

    public void restart()
    {
        gameover = false;
        start.SetActive(false);
        Debug.Log("restart");
        InvokeRepeating("SpawnTarget", 0f, Random.Range(minSpawnInterval, maxSpawnInterval));
        oldmouse = Camera.ScreenToWorldPoint(Input.mousePosition);
    }

    void SpawnTarget()
    {
        float randomX = Random.Range(-XRange, XRange);
        float randomY = Random.Range(-YRange, YRange);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
        pointlist[num] = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
        num++;

        if (num == 9)
        {
            num = 0;
        }
    }

    void CheckForClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            totalmousedown++;
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            for (int i = 0; i < 10; i++)
            {
                if (pointlist[i] != null)
                {

                    if (nowtarget > Vector3.Distance(pointlist[i].transform.position, mousePos))
                    {
                        nowtarget = Vector3.Distance(pointlist[i].transform.position, mousePos);
                        pouintnum = i;
                        //targetdistance = Vector3.Distance(mousePos, pointlist[pouintnum].transform.position);
                    }   
                }
            }

            targetdistance = Vector3.Distance(oldmouse, pointlist[pouintnum].transform.position);
            //Debug.Log(targetdistance);

            //포인트까지 클릭 지점
            float pointdistance = Vector3.Distance(pointlist[pouintnum].transform.position, pointlist[pouintnum].transform.position);
            //
            //Debug.Log(pointdistance);



            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("target"))
                {
                    Debug.Log("10점 ");
                    totalscore = totalscore + 10;

                    Destroy(hit.collider.gameObject, 0.1f);

                }
            }

            nowtarget = 200;
            oldmouse = mousePos;
        }
    }
}