using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousepoint : MonoBehaviour
{
    Camera Camera;
    public GameObject point_2d;
    public Transform pointlist; // pointlist ������Ʈ�� Transform�� ����մϴ�.

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Mouse Position (2D): ");
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ�� üũ
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            // point_2d ������Ʈ�� mousePos ��ġ�� �����ϰ� pointlist�� �ڽ����� �����մϴ�.
            GameObject newPoint = Instantiate(point_2d, new Vector3(mousePos.x, mousePos.y, 0f), Quaternion.identity);
            newPoint.transform.parent = pointlist;

            Debug.Log("Mouse Position (2D): " + mousePos);
        }
    }
}