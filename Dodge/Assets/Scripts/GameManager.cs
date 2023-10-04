using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spawner;                       //스포너 프리팹 오브젝트
    public GameObject player;                       //플레이어 오브젝트

    public List<GameObject> spawnList = new List<GameObject>();
    
    public float TotalTime = 0.0f;               //전체 체크 시간
    public float TimeCursor = 10.0f;             //간격 시간 설정(레벨)
    public float TimeCursorCheck = 0.0f;         //간격 시간 체크 float

    public int cursor = 0;                       //레벨 설정 커서
    public Transform[] spawnPos;                 //레벨 젠 추가 위치
  
    void Start()
    {
        GameObject temp = (GameObject)Instantiate(spawner);                     //스포너를 생성
        temp.transform.position = spawnPos[cursor].transform.position;          //받아온 위치로 이동
    }

    // Update is called once per frame
    void Update()
    {
        TotalTime += Time.deltaTime;                         //시간 흐르게 설정
        TimeCursorCheck += Time.deltaTime;

        if(TimeCursorCheck >= TimeCursor)
        {
            TimeCursorCheck = 0.0f;                         //단계 올라감 확인

            if(spawnPos.Length > cursor)
            {
                GameObject temp = (GameObject)Instantiate(spawner);                   //스포너를 생성
                spawnList.Add(temp);                                                //리스트를 스포너 입력
                temp.transform.position = spawnPos[cursor].transform.position;        //받아온 위치로 이동
            }
            cursor += 1;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i  < spawnList.Count; i++)
            {
                Destroy(spawnList[i]);
            }
            spawnList.Clear();
            TotalTime = 0.0f;
            TimeCursor = 10.0f;
            TimeCursorCheck = 0.0f;
            cursor = 0;

            player.SetActive(true);


            GameObject temp = (GameObject)Instantiate(spawner);                   //스포너를 생성
            spawnList.Add(temp);                                                //리스트를 스포너 입력
            temp.transform.position = spawnPos[cursor].transform.position;        //받아온 위치로 이동
        }
    }
}
