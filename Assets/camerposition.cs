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
            // "K" Ű�� ������ ����� ��ġ�� player�� �̵�
            player.transform.position = new Vector3(0f, 0f, 20f); // �� ��ġ ����
            player.transform.rotation = Quaternion.Euler(1f, 1f, 1f); // �� ���� ����

            object_1.transform.position = new Vector3(0f, 0f, 20f); // �� ��ġ ����
            object_1.transform.rotation = Quaternion.Euler(1f, 1f, 1f); // �� ���� ����
        }
    }
}
