using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8.0f;                 //ź�� �̵��ӷ�
    private Rigidbody bulletRigidBody;         //�̵��� ����� ������ٵ�
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();     //���� ���� ������Ʈ���� PlayerController ��������

            if(playerController != null)
            {
                playerController.Die();        //���� PlayerController ������Ʈ�� Die �ż��� ����
            }    
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //���� ������Ʈ���� Rigidbody ������Ʈ�� ã�Ƽ� BulletRigidbody�� �Ҵ�
        bulletRigidBody = GetComponent<Rigidbody>();
        //������ �ٵ� �ӵ� = ���� ���� * �̵��ӷ�
        bulletRigidBody.velocity = transform.forward * speed;

        //3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
