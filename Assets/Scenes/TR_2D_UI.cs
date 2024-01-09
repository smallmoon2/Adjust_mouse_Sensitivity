using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TR_2D_UI : MonoBehaviour
{
    public static int level;
    public GameObject TP;
    // Start is called before the first frame update

    public TextMeshProUGUI score;
    public TextMeshProUGUI timeText; // 시간을 표시할 TextMeshPro 오브젝트

    public TR_2D_test TR_2D_test;
    public Text scoretext;
    public Text accuracytext;
    public Text correctiontext;

    private void Start()
    {
        level = 0;
    }
    void Update()
    {
        scoretext.text = TR_2D_test.totalscore.ToString();


        if (TR_2D_test.totalmousedown != 0)
        {
            accuracytext.text = (TR_2D_test.totalscore * 10 / TR_2D_test.totalmousedown).ToString();
        }


        //correctiontext.text = 

        score.text = "score : " + TR_2D_test.totalscore.ToString();
        timeText.text = TR_2D_test.currentTime.ToString("F2"); // "F2" 포맷을 사용하여 소수점 2자리까지 표시

    }

        public void OnClick()
    {

        level++;

        //Cursor.visible = false;
        
        TP.GetComponent<TR_2D_test>().restart();
        //Cursor.visible = false;
    }

    public void returnhome()
    {
        SceneManager.LoadScene("mainsene");
    }
}
