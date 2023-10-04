using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidBody;           //�÷��̾� �̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8.0f;                  //�̵� �ӷ�

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.UpArrow) == true)           //���� ����Ű �Է��� ������ ��� z���� ���ֱ�
        //{
        //    playerRigidBody.AddForce(0f, 0f, speed);        //���ʹ��� == Z��
        //}
        //if (Input.GetKey(KeyCode.DownArrow) == true)        //�Ʒ��� ����Ű �Է��� ������ ��� z���� ���ֱ�
        //{
        //    playerRigidBody.AddForce(0f, 0f, -speed);       //�Ʒ����� == -Z��
        //}
        //if (Input.GetKey(KeyCode.RightArrow) == true)       //������ ����Ű �Է��� ������ ��� z���� ���ֱ�
        //{
        //    playerRigidBody.AddForce(speed, 0f, 0f);        //�����ʹ��� == X��
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) == true)        //���� ����Ű �Է��� ������ ��� z���� ���ֱ�
        //{
        //    playerRigidBody.AddForce(-speed, 0f, 0f);       //���ʹ��� == -X��
        //}


        float xInput = Input.GetAxis("Horizontal");     //������
        float zInput = Input.GetAxis("Vertical");     //������

        Debug.Log("xInput :" + xInput + "zInput : " + zInput);          //�ӵ��� ����׷α׷� �ؽ�Ʈ�� ����� �ܼ�â���� �ӵ��� ��ȭ�� �����ְ� ��

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);      //Vector3 �ӵ��� (xSpeed, 0 ,zSpeed)�� ����
        playerRigidBody.velocity = newVelocity;                     //������ٵ��� �ӵ��� newVelocity �Ҵ�



    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
