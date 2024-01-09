using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // Random Ŭ������ ����ϱ� ���� �߰�
using Demo.Scripts.Runtime; // �� �κ��� �߰�

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
        // targetlist�� �ڽ� ������Ʈ���� ã�Ƽ� Animator ������Ʈ ��������
        GetChildAnimators(targetlist);
        alldown();
        // 2�ʸ��� ������ �ڽ� ������Ʈ�� "hit_up" Ʈ���� ����
        //StartCoroutine(RandomlyTriggerHitUp());
    }

    private void Update()
    {
        if (gameplay == true)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0.0f)
            {
                currentTime = 0.0f; // �ð��� 0���� �۾����� 0���� ����
            }

            if (Input.GetMouseButtonDown(0))
            {

                //Debug.Log("Ÿ�� ��ũ��Ʈ");

                carmeranowvector = playercarmera.transform.forward;
                bullet--;

                //Debug.Log(bullet);
                if (bullet <= 0)
                {
                    //Debug.Log("���� ����");
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
    // targetlist�� �ڽ� ������Ʈ���� Animator ������Ʈ ��������
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

    // 2�ʸ��� ������ �ڽ� ������Ʈ�� "hit_up" Ʈ���� �����ϴ� �ڷ�ƾ
    IEnumerator RandomlyTriggerHitUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);


            carmeranowvector = playercarmera.transform.forward;
            
            childAnimators[randomIndex].SetTrigger("changedown");
            // ������ �ڽ� ������Ʈ ����
            randomIndex = Random.Range(0, childAnimators.Count);

            targetvector = targetlist.transform.GetChild(randomIndex).position;
            targetvector.y += 0.95f;
            //lasttarget = randomIndex;
            // ������ �ڽ� ������Ʈ�� "hit_up" Ʈ���� ����
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

        //Debug.Log(Level + "��° ����");

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

            // ����� �α׿� ���
            //Debug.Log( "�Ͼ Ÿ�� ��ȣ"+ selectedIndices[i]);



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
        //Debug.Log(Level + "��° ����");
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