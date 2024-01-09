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
    public TextMeshProUGUI timeText; // 시간을 표시할 TextMeshPro 오브젝트

    
     
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "score : " + targetdistance.totalscore.ToString();
        timeText.text = targetmove.currentTime.ToString("F2"); // "F2" 포맷을 사용하여 소수점 2자리까지 표시


        // 시간 감소 로직


        // 갱신된 시간을 텍스트로 표시

    }


}