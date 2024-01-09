using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UIview2D : MonoBehaviour
{
    public targetpoint targetpoint;
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
        scoretext.text = targetpoint.totalscore2D.ToString();


        accuracytext.text = (100 - (int)(targetpoint.totalaccuracy2D * 100 / (targetpoint.totalcheck * 2))).ToString() + "%";
        Debug.Log((100 - (int)(targetpoint.totalaccuracy2D * 100 / (targetpoint.totalcheck * 2))));

        correctiontext.text = ( targetpoint.totaldistance / targetpoint.totalpointdistance).ToString();
    }
    
    public void click()
    {
        SceneManager.LoadScene("mainsene");
    }
}
