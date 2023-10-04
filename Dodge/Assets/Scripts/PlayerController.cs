using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidBody;           //플레이어 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8.0f;                  //이동 속력

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.UpArrow) == true)           //위쪽 방향키 입력이 감지된 경우 z방향 힘주기
        //{
        //    playerRigidBody.AddForce(0f, 0f, speed);        //위쪽방향 == Z축
        //}
        //if (Input.GetKey(KeyCode.DownArrow) == true)        //아래쪽 방향키 입력이 감지된 경우 z방향 힘주기
        //{
        //    playerRigidBody.AddForce(0f, 0f, -speed);       //아래방향 == -Z축
        //}
        //if (Input.GetKey(KeyCode.RightArrow) == true)       //오른쪽 방향키 입력이 감지된 경우 z방향 힘주기
        //{
        //    playerRigidBody.AddForce(speed, 0f, 0f);        //오른쪽방향 == X축
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) == true)        //왼쪽 방향키 입력이 감지된 경우 z방향 힘주기
        //{
        //    playerRigidBody.AddForce(-speed, 0f, 0f);       //왼쪽방향 == -X축
        //}


        float xInput = Input.GetAxis("Horizontal");     //수평축
        float zInput = Input.GetAxis("Vertical");     //수직축

        Debug.Log("xInput :" + xInput + "zInput : " + zInput);          //속도를 디버그로그로 텍스트로 출력해 콘솔창에서 속도의 변화를 볼수있게 함

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);      //Vector3 속도를 (xSpeed, 0 ,zSpeed)로 생성
        playerRigidBody.velocity = newVelocity;                     //리지드바디의 속도에 newVelocity 할당



    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
