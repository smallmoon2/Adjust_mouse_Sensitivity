using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raygun : MonoBehaviour
{
    public float raycastDistance = 10f; // 레이의 최대 거리
    public GameObject bulletimpactPrefab; // bulletimpact 프리팹

    void Update()
    {
        // 마우스 왼쪽 버튼 클릭 검사
        if (Input.GetMouseButtonDown(0))
        {
            // 카메라의 중심점을 기준으로 레이캐스트 발사
            Camera mainCamera = Camera.main;
            Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            Ray ray = new Ray(rayOrigin, mainCamera.transform.forward);

            RaycastHit hit;

            // 레이캐스트 발사
            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                // 충돌한 물체의 정보 출력
                //Debug.Log("충돌한 오브젝트: " + hit.collider.gameObject.name);

                // 충돌 지점에 bulletimpact 프리팹을 생성
                Instantiate(bulletimpactPrefab, hit.point + new Vector3(0.02f, 0.02f, -0.02f), Quaternion.LookRotation(-hit.normal));
            }
        }
    }
}