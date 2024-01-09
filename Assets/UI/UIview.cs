using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UIview : MonoBehaviour
{

    public targetdistance targetdistance;
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
        scoretext.text = targetdistance.totalscore.ToString();

        
        accuracytext.text = (100 - (int)(targetdistance.totalaccuracy * 100 / (targetdistance.totalbullet * 2.6))).ToString() + "%";
        //Debug.Log(targetdistance.totalaccuracy);
        //Debug.Log(targetdistance.totalbullet);
        //Debug.Log((int)(targetdistance.totalaccuracy * 100 / (targetdistance.totalbullet * 2.6)));


        correctiontext.text = targetdistance.totalSensitivity.ToString();
    }

    public void returnhome()
    {
        SceneManager.LoadScene("mainsene");
    }
}
