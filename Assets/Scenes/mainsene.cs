using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainsene : MonoBehaviour
{
    public int startscens;

    Image[] sr; // Change to Image array
    public GameObject[] asd = new GameObject[4]; // Change to GameObject array
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Initialize the Image array
        sr = new Image[asd.Length];

        // Assign each Image component to the array
        for (int i = 0; i < asd.Length; i++)
        {
            sr[i] = asd[i].GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ResetColors()
    {
        // Set all Image components to black
        foreach (Image image in sr)
        {
            image.color = Color.black;
        }
    }

    public void TRAINING2D()
    {
        startscens = 1;
        ResetColors();
        // Assuming you want to change the color of the first Image component to cyan
        sr[0].color = Color.cyan;
    }

    public void CORRECTION2D()
    {
        startscens = 2;
        ResetColors();
        // Assuming you want to change the color of the second Image component to cyan
        sr[1].color = Color.cyan;
    }

    public void TRAINING3D()
    {
        startscens = 3;
        ResetColors();
        // Assuming you want to change the color of the third Image component to cyan
        sr[2].color = Color.cyan;
    }

    public void CORRECTION3D()
    {
        startscens = 4;
        ResetColors();
        // Assuming you want to change the color of the fourth Image component to cyan
        sr[3].color = Color.cyan;
    }

    public void Onclick()
    {
        switch (startscens)
        {
            case 1:
                SceneManager.LoadScene("2d_M_TR");
                break;
            case 2:
                SceneManager.LoadScene("2d_M_CR");
                break;
            case 3:
                SceneManager.LoadScene("3d_M_TR");
                break;
            case 4:
                SceneManager.LoadScene("3d M_CR");
                break;
            default:
                Debug.LogError("Invalid startscens value: " + startscens);
                break;
        }
    }
}