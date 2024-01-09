using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    public GameObject cubePrefab;      // ������ Cube ������
    public float minRange = -35f;       // �ּ� ���� ����
    public float maxRange = 35f;        // �ִ� ���� ����
    public float generationInterval = 2f; // Cube ���� ����

    private List<GameObject> cubes = new List<GameObject>(); // ������ Cube���� ������ ����Ʈ

    // Start �Լ����� ���� �������� GenerateCube �Լ��� ȣ���ϴ� �ڷ�ƾ�� �����մϴ�.
    void Start()
    {
        StartCoroutine(GenerateCubeCoroutine());
    }

    // Cube ���� �ڷ�ƾ
    IEnumerator GenerateCubeCoroutine()
    {
        while (true)
        {
            // ������ ������ Cube ����
            DestroyPreviousCubes();

            // ������ ��ġ ����
            float randomX = Random.Range(minRange, maxRange);
            float randomY = 3f;
            float randomZ = Random.Range(10f, maxRange);
            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            // Cube ����
            GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
            cubes.Add(cube);

            yield return new WaitForSeconds(generationInterval);
        }
    }

    // ������ ������ Cube ���� �Լ�
    void DestroyPreviousCubes()
    {
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }
        cubes.Clear();
    }
}