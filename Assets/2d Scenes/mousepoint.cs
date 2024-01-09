using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousepoint : MonoBehaviour
{
    Camera Camera;
    public GameObject point_2d;
    public Transform pointlist; // pointlist 오브젝트의 Transform을 사용합니다.

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


        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 체크
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.ScreenToWorldPoint(mousePos);

            // point_2d 오브젝트를 mousePos 위치에 생성하고 pointlist의 자식으로 설정합니다.
            GameObject newPoint = Instantiate(point_2d, new Vector3(mousePos.x, mousePos.y, 0f), Quaternion.identity);
            newPoint.transform.parent = pointlist;

            Debug.Log("Mouse Position (2D): " + mousePos);
        }
    }
}