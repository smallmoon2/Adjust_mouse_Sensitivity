using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score_time : MonoBehaviour
{
    public targetdistance targetdistance;
    public targetmove targetmove;
    public TextMeshProUGUI score;
    public TextMeshProUGUI timeText; // �ð��� ǥ���� TextMeshPro ������Ʈ

    
     
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "score : " + targetdistance.totalscore.ToString();
        timeText.text = targetmove.currentTime.ToString("F2"); // "F2" ������ ����Ͽ� �Ҽ��� 2�ڸ����� ǥ��


        // �ð� ���� ����


        // ���ŵ� �ð��� �ؽ�Ʈ�� ǥ��

    }


}