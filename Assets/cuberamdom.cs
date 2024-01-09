using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuberamdom : MonoBehaviour
{
    public GameObject player;
    private float teleportInterval = 2f;  // �����̵� ����
    private Vector3 targetPosition;       // ��ǥ �̵� ��ġ
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
        // ť���� ��ġ�� ��ǥ �̵� ��ġ�� ����
        transform.position = targetPosition;
    }

    // 2�ʸ��� �����̵��Ͽ� ������ ��ǥ�� �̵��ϴ� �ڷ�ƾ
    IEnumerator TeleportCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportInterval);

            SetRandomTargetPosition();
        }
    }

    // ��ǥ �̵� ��ġ�� ������ ��ǥ�� ����
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

            Destroy(other.gameObject); // �浹�� bullet ������Ʈ ����
            meshRenderer.enabled = false;
        }
    }

}
