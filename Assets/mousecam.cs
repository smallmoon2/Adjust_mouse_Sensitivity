using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecam : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 5f;
    public float rotationSpeed = 0.1f;
    float mx = 0;
    float my = 0;
    void Update()
    {
        // 마우스 입력으로 화면 회전
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        mx += h * rotationSpeed;
        my += v * rotationSpeed;

        if (my >= 90)
        {
            my = 90;
        }
        else if (my <= -90)
        {
            my = -90;
        }
        transform.eulerAngles = new Vector3(-my, mx, 0);

        // 키보드 입력으로 이동
        h = Input.GetAxis("Horizontal");        // 가로축
        v = Input.GetAxis("Vertical");          // 세로축

        // Point 2.
        Vector3 movement = new Vector3(h, 0, v) * movementSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0); // 현재 Y 회전값 유지
        movement = rotation * movement; // 이동 방향을 현재 회전값으로 변환
        transform.Translate(movement, Space.World);
    }


}
