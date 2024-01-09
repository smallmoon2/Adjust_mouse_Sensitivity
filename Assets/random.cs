using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    public GameObject cubePrefab;      // 생성할 Cube 프리팹
    public float minRange = -35f;       // 최소 생성 범위
    public float maxRange = 35f;        // 최대 생성 범위
    public float generationInterval = 2f; // Cube 생성 간격

    private List<GameObject> cubes = new List<GameObject>(); // 생성된 Cube들을 저장할 리스트

    // Start 함수에서 일정 간격으로 GenerateCube 함수를 호출하는 코루틴을 시작합니다.
    void Start()
    {
        StartCoroutine(GenerateCubeCoroutine());
    }

    // Cube 생성 코루틴
    IEnumerator GenerateCubeCoroutine()
    {
        while (true)
        {
            // 이전에 생성된 Cube 삭제
            DestroyPreviousCubes();

            // 랜덤한 위치 생성
            float randomX = Random.Range(minRange, maxRange);
            float randomY = 3f;
            float randomZ = Random.Range(10f, maxRange);
            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            // Cube 생성
            GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
            cubes.Add(cube);

            yield return new WaitForSeconds(generationInterval);
        }
    }

    // 이전에 생성된 Cube 삭제 함수
    void DestroyPreviousCubes()
    {
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }
        cubes.Clear();
    }
}