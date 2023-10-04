using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f;         //새 탄알을 생성하는 데 걸리는 시간의 최솟값
    public float spawnRateMax = 3.0f;         //새 탄알을 생성하는 데 걸리는 시간의 최댓값

    private Transform target;       //발사할 대상
    private float spawnRate;        //생성 주기
    private float timeAfterSpawn;   //최근 생성 시점에서 지난 시간


    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0.0f;   //최근 생성 이후의 누적시간을 0초로 초기화

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);   //탄알 생성 간격을 랜덤 지정

        target = FindObjectOfType<PlayerController>().transform;    //PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 지정
    }

     void Update()
    {
        timeAfterSpawn += Time.deltaTime;       //tomeAfterspawn 갱신
        //최근 생성 시점에서부터 누적된 시간이 생성 주기가 크거나 같다면

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0.0f;      //누적된 시간을 리셋

            this.gameObject.transform.LookAt(target, Vector3.up);             //스포너가 플레이어를 향하게
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);          //bullet 복제본 생성
            bullet.transform.LookAt(target);                                                        //생성된 Bullet의 방향이 Target을 향하도록

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);          //다음번 생성 간격을 랜덤 지정
        }
    }
        

        
    
}



