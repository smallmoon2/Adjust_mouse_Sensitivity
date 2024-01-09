using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuberamdom : MonoBehaviour
{
    public GameObject player;
    private float teleportInterval = 2f;  // 순간이동 간격
    private Vector3 targetPosition;       // 목표 이동 위치
    private MeshRenderer meshRenderer;
    public Vector3 nowvector;
    void Start()
    {

        nowvector = player.transform.forward;
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(TeleportCoroutine());
    }

    void Update()
    {
        // 큐브의 위치를 목표 이동 위치로 설정
        transform.position = targetPosition;
    }

    // 2초마다 순간이동하여 랜덤한 좌표로 이동하는 코루틴
    IEnumerator TeleportCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportInterval);

            SetRandomTargetPosition();
        }
    }

    // 목표 이동 위치를 랜덤한 좌표로 설정
    void SetRandomTargetPosition()
    {

        float randomX = Random.Range(-3, -15);
        float randomY = 3f;
        float randomZ = Random.Range(-14, 0);
        targetPosition = new Vector3(randomX, randomY, randomZ);


        nowvector = player.transform.forward;
        Debug.Log(nowvector);
        meshRenderer.enabled = true;
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("bullet"))
        {

            Destroy(other.gameObject); // 충돌한 bullet 오브젝트 삭제
            meshRenderer.enabled = false;
        }
    }

}
