using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startUI : MonoBehaviour
{
    public static int level;
    public GameObject TP;
    // Start is called before the first frame update


    private void Start()
    {
        level = 0;
    }
    public void OnClick()
    {

        level ++ ;

        //Cursor.visible = false;
        TP.GetComponent<targetpoint>().mousereset();
        TP.GetComponent<targetpoint>().restart();
        Cursor.visible = false;
    }

}
