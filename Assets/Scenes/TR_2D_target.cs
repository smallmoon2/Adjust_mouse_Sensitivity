using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_2D_target : MonoBehaviour
{
public float scaleSpeed = 2.0f; // ũ�� ��ȭ �ӵ�

    Vector3 initialScale; // �ʱ� ũ��

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        StartCoroutine(ScaleTarget());
    }

    // Coroutine���� ũ�� ��ȭ �� ���� ����
    IEnumerator ScaleTarget()
    {
        while (transform.localScale.x < 4f)
        {
            float scaleAmount = Time.deltaTime * scaleSpeed;
            transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);
            yield return null;
        }

        // ũ�Ⱑ 2.5f �̻��� �Ǹ� �ʱ� ũ��� �ǵ�����, ���� �ð� ��� �� ����
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
        // ���ϴ� �ٸ� ������ ������ ���⿡ �߰�
    }
}
