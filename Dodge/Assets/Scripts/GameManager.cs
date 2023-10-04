using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spawner;                       //������ ������ ������Ʈ
    public GameObject player;                       //�÷��̾� ������Ʈ

    public List<GameObject> spawnList = new List<GameObject>();
    
    public float TotalTime = 0.0f;               //��ü üũ �ð�
    public float TimeCursor = 10.0f;             //���� �ð� ����(����)
    public float TimeCursorCheck = 0.0f;         //���� �ð� üũ float

    public int cursor = 0;                       //���� ���� Ŀ��
    public Transform[] spawnPos;                 //���� �� �߰� ��ġ
  
    void Start()
    {
        GameObject temp = (GameObject)Instantiate(spawner);                     //�����ʸ� ����
        temp.transform.position = spawnPos[cursor].transform.position;          //�޾ƿ� ��ġ�� �̵�
    }

    // Update is called once per frame
    void Update()
    {
        TotalTime += Time.deltaTime;                         //�ð� �帣�� ����
        TimeCursorCheck += Time.deltaTime;

        if(TimeCursorCheck >= TimeCursor)
        {
            TimeCursorCheck = 0.0f;                         //�ܰ� �ö� Ȯ��

            if(spawnPos.Length > cursor)
            {
                GameObject temp = (GameObject)Instantiate(spawner);                   //�����ʸ� ����
                spawnList.Add(temp);                                                //����Ʈ�� ������ �Է�
                temp.transform.position = spawnPos[cursor].transform.position;        //�޾ƿ� ��ġ�� �̵�
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


            GameObject temp = (GameObject)Instantiate(spawner);                   //�����ʸ� ����
            spawnList.Add(temp);                                                //����Ʈ�� ������ �Է�
            temp.transform.position = spawnPos[cursor].transform.position;        //�޾ƿ� ��ġ�� �̵�
        }
    }
}
