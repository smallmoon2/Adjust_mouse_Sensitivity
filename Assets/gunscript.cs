using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    public Transform bulletSpawnPoint;  // 총알 발사 위치
    public GameObject bulletPrefab;     // 총알 프리팹
    public float bulletSpeed = 100f;     // 총알 속도
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    } 
    // 매 프레임마다 호출되는 함수
    void Update()
    {

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        // 마우스 왼쪽 버튼을 클릭했을 때 총알 발사
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    // 총알 발사 함수
    void Shoot()
    {
        // 총알 프리팹을 인스턴스화하여 총알 게임오브젝트 생성
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // 총알에 속도를 부여
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        bullet.transform.Rotate(Vector3.right, 90f);

        bulletRigidbody.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);

        bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;

        // 일정 시간 후에 총알 삭제
        Destroy(bullet, 2f);
    }
}
