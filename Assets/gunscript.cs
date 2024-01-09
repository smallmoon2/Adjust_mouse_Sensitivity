using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    public Transform bulletSpawnPoint;  // �Ѿ� �߻� ��ġ
    public GameObject bulletPrefab;     // �Ѿ� ������
    public float bulletSpeed = 100f;     // �Ѿ� �ӵ�
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    } 
    // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        // ���콺 ���� ��ư�� Ŭ������ �� �Ѿ� �߻�
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    // �Ѿ� �߻� �Լ�
    void Shoot()
    {
        // �Ѿ� �������� �ν��Ͻ�ȭ�Ͽ� �Ѿ� ���ӿ�����Ʈ ����
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // �Ѿ˿� �ӵ��� �ο�
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        bullet.transform.Rotate(Vector3.right, 90f);

        bulletRigidbody.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);

        bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;

        // ���� �ð� �Ŀ� �Ѿ� ����
        Destroy(bullet, 2f);
    }
}
