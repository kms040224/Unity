using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8.0f;                 //탄알 이동속력
    private Rigidbody bulletRigidBody;         //이동에 사용할 리지드바디
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();     //상대방 게임 오브젝트에서 PlayerController 가져오기

            if(playerController != null)
            {
                playerController.Die();        //상대방 PlayerController 컴포넌트의 Die 매서드 실행
            }    
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아서 BulletRigidbody에 할당
        bulletRigidBody = GetComponent<Rigidbody>();
        //리지드 바디 속도 = 앞쪽 방향 * 이동속력
        bulletRigidBody.velocity = transform.forward * speed;

        //3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
