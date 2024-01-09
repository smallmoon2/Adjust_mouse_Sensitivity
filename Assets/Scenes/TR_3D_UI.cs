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
    public TextMeshProUGUI timeText; // �ð��� ǥ���� TextMeshPro ������Ʈ

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
        timeText.text = TR_3D_target.currentTime.ToString("F2"); // "F2" ������ ����Ͽ� �Ҽ��� 2�ڸ����� ǥ��

        scoretext.text = TR_3D_test.totalscore.ToString();


        accuracytext.text = (100 - (int)(TR_3D_test.totalaccuracy * 100 / (TR_3D_test.totalbullet * 2.6))).ToString() + "%";

        Debug.Log(TR_3D_test.totalSensitivity);

        correctiontext.text = TR_3D_test.totalSensitivity.ToString();
        // �ð� ���� ����


        // ���ŵ� �ð��� �ؽ�Ʈ�� ǥ��

    }
    public void retrunhome()
    {
        SceneManager.LoadScene("mainsene");
    }
}
