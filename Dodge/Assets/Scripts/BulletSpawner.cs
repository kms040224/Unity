using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //������ ź���� ���� ������
    public float spawnRateMin = 0.5f;         //�� ź���� �����ϴ� �� �ɸ��� �ð��� �ּڰ�
    public float spawnRateMax = 3.0f;         //�� ź���� �����ϴ� �� �ɸ��� �ð��� �ִ�

    private Transform target;       //�߻��� ���
    private float spawnRate;        //���� �ֱ�
    private float timeAfterSpawn;   //�ֱ� ���� �������� ���� �ð�


    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0.0f;   //�ֱ� ���� ������ �����ð��� 0�ʷ� �ʱ�ȭ

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);   //ź�� ���� ������ ���� ����

        target = FindObjectOfType<PlayerController>().transform;    //PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
    }

     void Update()
    {
        timeAfterSpawn += Time.deltaTime;       //tomeAfterspawn ����
        //�ֱ� ���� ������������ ������ �ð��� ���� �ֱⰡ ũ�ų� ���ٸ�

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0.0f;      //������ �ð��� ����

            this.gameObject.transform.LookAt(target, Vector3.up);             //�����ʰ� �÷��̾ ���ϰ�
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);          //bullet ������ ����
            bullet.transform.LookAt(target);                                                        //������ Bullet�� ������ Target�� ���ϵ���

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);          //������ ���� ������ ���� ����
        }
    }
        

        
    
}



