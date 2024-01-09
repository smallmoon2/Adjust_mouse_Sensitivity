using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerposition : MonoBehaviour
{
    public GameObject player;
    public GameObject object_1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            // "K" 키를 누르면 저장된 위치로 player를 이동
            player.transform.position = new Vector3(0f, 0f, 20f); // 새 위치 설정
            player.transform.rotation = Quaternion.Euler(1f, 1f, 1f); // 새 방향 설정

            object_1.transform.position = new Vector3(0f, 0f, 20f); // 새 위치 설정
            object_1.transform.rotation = Quaternion.Euler(1f, 1f, 1f); // 새 방향 설정
        }
    }
}
