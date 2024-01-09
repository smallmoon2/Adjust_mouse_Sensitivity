using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // Random 클래스를 사용하기 위해 추가
using Demo.Scripts.Runtime; // 이 부분을 추가

public class targetmove : MonoBehaviour
{
    public GameObject camreplay;
    public GameObject EndUi;

    public float currentTime = 5.0f;

    public FPSController fpsController;

    public Camera replaycam;
    public Camera fixcam;

    public GameObject playercarmera;

    public GameObject targetlist;
    public List<Animator> childAnimators = new List<Animator>();

    public Vector3 carmeranowvector;
    public Vector3 targetvector;

    public Vector3[] targetVectors = new Vector3[3];

    public int bullet = 0;

    public int lasttarget;

    public int[] stage = { 1, 1, 1, 2, 2, 2, 3, 3, 3 };

    public int Level = 0;
    public bool nextlevel = true;

    public bool gameplay = true;

    public List<int> selectedIndices = new List<int>();

    int randomIndex ;
    // Start is called before the first frame update
    void Start()
    {

        carmeranowvector = playercarmera.transform.forward;
        // targetlist의 자식 오브젝트들을 찾아서 Animator 컴포넌트 가져오기
        GetChildAnimators(targetlist);
        alldown();
        // 2초마다 무작위 자식 오브젝트의 "hit_up" 트리거 실행
        //StartCoroutine(RandomlyTriggerHitUp());
    }

    private void Update()
    {
        if (gameplay == true)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0.0f)
            {
                currentTime = 0.0f; // 시간이 0보다 작아지면 0으로 고정
            }

            if (Input.GetMouseButtonDown(0))
            {

                //Debug.Log("타깃 스크립트");

                carmeranowvector = playercarmera.transform.forward;
                bullet--;

                //Debug.Log(bullet);
                if (bullet <= 0)
                {
                    //Debug.Log("비디오 시작");
                    Invoke("CallStartPlayback", 1.0f);
                    
                }

            }

            if (nextlevel == true)
            {
                start_nextlevel();
                nextlevel = false;
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                currentTime = 5.0f;
                fpsController.startmove();
                fixcam.depth = 2;
                carmeranowvector = playercarmera.transform.forward;
                targetup();
            }
        }
        
    }
    // targetlist의 자식 오브젝트에서 Animator 컴포넌트 가져오기
    void GetChildAnimators(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Animator childAnimator = child.GetComponent<Animator>();
            if (childAnimator != null)
            {
                childAnimators.Add(childAnimator);
            }
        }
    }

    // 2초마다 무작위 자식 오브젝트의 "hit_up" 트리거 실행하는 코루틴
    IEnumerator RandomlyTriggerHitUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);


            carmeranowvector = playercarmera.transform.forward;
            
            childAnimators[randomIndex].SetTrigger("changedown");
            // 무작위 자식 오브젝트 선택
            randomIndex = Random.Range(0, childAnimators.Count);

            targetvector = targetlist.transform.GetChild(randomIndex).position;
            targetvector.y += 0.95f;
            //lasttarget = randomIndex;
            // 선택한 자식 오브젝트의 "hit_up" 트리거 실행
            //childAnimators[randomIndex].SetTrigger("Exit");
            childAnimators[randomIndex].SetTrigger("changeup");   
        }
    }
    
    void targetup()
    {

        if (Level == 9)
        {
            gameplay = false;
            fixcam.depth = 2;
            EndUi.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            return;
        }
        replaycam.depth = 0;

        camreplay.GetComponent<camreplay>().StartRecording();

        //Debug.Log(Level + "번째 시작");

        bullet = stage[Level];
        if (selectedIndices.Count > 0)
        {
            foreach (int index in selectedIndices)
            {
                //childAnimators[index].SetTrigger("changedown");
            }
            selectedIndices.Clear();
        }

        for (int i = 0; i < stage[Level]; i++)
        {

             
            do
            {
                randomIndex = Random.Range(0, childAnimators.Count);
            } while (selectedIndices.Contains(randomIndex));

            selectedIndices.Add(randomIndex);
            targetVectors[i]  = targetlist.transform.GetChild(randomIndex).position;
            targetVectors[i].y += 0.95f;

            childAnimators[selectedIndices[i]].SetTrigger("changeup");

            // 디버그 로그에 출력
            //Debug.Log( "일어난 타겟 번호"+ selectedIndices[i]);



        }



        Level++;

    }
    void alldown()
    {
        for (int i = 0; i < childAnimators.Count; i++)
        {
            childAnimators[i].SetTrigger("hit_down");
        }
    }
    void CallStartPlayback()
    {
        
        camreplay.GetComponent<camreplay>().StopRecording();
        camreplay.GetComponent<camreplay>().StartPlayback();
        //Debug.Log(Level + "번째 종료");
        replaycam.depth = 3;
    }

    void start_nextlevel()
    {
        currentTime = 5.0f;
        fpsController.startmove();
        fixcam.depth = 2;
        carmeranowvector = playercarmera.transform.forward;
        targetup();
    }
}