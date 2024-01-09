using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raygun : MonoBehaviour
{
    public float raycastDistance = 10f; // ������ �ִ� �Ÿ�
    public GameObject bulletimpactPrefab; // bulletimpact ������

    void Update()
    {
        // ���콺 ���� ��ư Ŭ�� �˻�
        if (Input.GetMouseButtonDown(0))
        {
            // ī�޶��� �߽����� �������� ����ĳ��Ʈ �߻�
            Camera mainCamera = Camera.main;
            Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            Ray ray = new Ray(rayOrigin, mainCamera.transform.forward);

            RaycastHit hit;

            // ����ĳ��Ʈ �߻�
            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                // �浹�� ��ü�� ���� ���
                //Debug.Log("�浹�� ������Ʈ: " + hit.collider.gameObject.name);

                // �浹 ������ bulletimpact �������� ����
                Instantiate(bulletimpactPrefab, hit.point + new Vector3(0.02f, 0.02f, -0.02f), Quaternion.LookRotation(-hit.normal));
            }
        }
    }
}