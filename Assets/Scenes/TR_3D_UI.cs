using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TR_3D_UI : MonoBehaviour
{
    public TR_3D_target TR_3D_target;
    public TR_3D_test TR_3D_test;
    public TextMeshProUGUI score;
    public TextMeshProUGUI timeText; // 시간을 표시할 TextMeshPro 오브젝트

    public Text scoretext;
    public Text accuracytext;
    public Text correctiontext;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "score : " + TR_3D_test.totalscore.ToString();
        timeText.text = TR_3D_target.currentTime.ToString("F2"); // "F2" 포맷을 사용하여 소수점 2자리까지 표시

        scoretext.text = TR_3D_test.totalscore.ToString();


        accuracytext.text = (100 - (int)(TR_3D_test.totalaccuracy * 100 / (TR_3D_test.totalbullet * 2.6))).ToString() + "%";

        Debug.Log(TR_3D_test.totalSensitivity);

        correctiontext.text = TR_3D_test.totalSensitivity.ToString();
        // 시간 감소 로직


        // 갱신된 시간을 텍스트로 표시

    }
    public void retrunhome()
    {
        SceneManager.LoadScene("mainsene");
    }
}
