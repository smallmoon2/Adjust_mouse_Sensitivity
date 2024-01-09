using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_2D_target : MonoBehaviour
{
public float scaleSpeed = 2.0f; // 크기 변화 속도

    Vector3 initialScale; // 초기 크기

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        StartCoroutine(ScaleTarget());
    }

    // Coroutine으로 크기 변화 및 제거 구현
    IEnumerator ScaleTarget()
    {
        while (transform.localScale.x < 4f)
        {
            float scaleAmount = Time.deltaTime * scaleSpeed;
            transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);
            yield return null;
        }

        // 크기가 2.5f 이상이 되면 초기 크기로 되돌리고, 일정 시간 대기 후 제거
        while (transform.localScale.x > 2f)
        {
            float scaleAmount = Time.deltaTime * scaleSpeed;
            transform.localScale -= new Vector3(scaleAmount, scaleAmount, scaleAmount);
            yield return null;
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // 원하는 다른 로직이 있으면 여기에 추가
    }
}
