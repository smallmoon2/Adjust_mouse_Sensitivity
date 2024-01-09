using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // Random 클래스를 사용하기 위해 추가
using Demo.Scripts.Runtime; // 이 부분을 추가

public class TR_3D_target : MonoBehaviour
{
    public GameObject endcam;
    public bool gameplayer = true;
    public GameObject targetlist;
    public TR_3D_test TR_3D_test;
    public FPSController fpsController;
    public GameObject EndUi;
    public List<Animator> childAnimators = new List<Animator>();
    public Vector3[] targetVectors = new Vector3[10];
    public Vector3 carmeranowvector;
    public List<int> selectedIndices = new List<int>();
    public GameObject playercarmera;


    public float currentTime = 20.0f;

    int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        carmeranowvector = playercarmera.transform.forward;
        GetChildAnimators(targetlist);
        fpsController.startmove();
        targetup();
        alldown();
    }

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

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0.0f)
        {
            currentTime = 0.0f; // 시간이 0보다 작아지면 0으로 고정
            gameplayer = false;
            EndUi.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            endcam.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            carmeranowvector = playercarmera.transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            onetargetup();
        }
    }

    void alldown()
    {
        for (int i = 0; i < childAnimators.Count; i++)
        {
            childAnimators[i].SetTrigger("hit_down");
        }
    }

    public void onetargetup()
    {


        do
        {
            randomIndex = Random.Range(0, childAnimators.Count);
        } while (selectedIndices.Contains(randomIndex));

        selectedIndices[TR_3D_test.downnum] = randomIndex;
        targetVectors[TR_3D_test.downnum] = targetlist.transform.GetChild(randomIndex).position;
        targetVectors[TR_3D_test.downnum].y += 0.95f;
        childAnimators[randomIndex].SetTrigger("changeup");




    }
    void targetup()
    {
        if (childAnimators.Count >= 5)
        {
            for (int i = 0; i < 5; i++)
            {
                do
                {
                    randomIndex = Random.Range(0, childAnimators.Count);
                } while (selectedIndices.Contains(randomIndex));

                selectedIndices.Add(randomIndex);

                //Debug.Log(targetVectors);

                targetVectors[i] = targetlist.transform.GetChild(randomIndex).position;
                targetVectors[i].y += 0.95f;

                //Debug.Log(selectedIndices[i]);
                childAnimators[selectedIndices[i]].SetTrigger("changeup");
            }
        }
        else
        {
            Debug.LogError("충분한 자식 애니메이터가 없습니다. targetup 작업이 수행되지 않았습니다.");
        }
    }
}
