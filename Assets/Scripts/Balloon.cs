using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public Rigidbody heavyObject; // ����ĸ���
    public float liftForce = 10f; // ����ĸ���

    public float acceleration = 10f;

    private Rigidbody balloonRigidbody;


    private void Start()
    {
        balloonRigidbody = GetComponent<Rigidbody>();
    }

    public void Combine(Rigidbody heavyObject)
    {
        balloonRigidbody = GetComponent<Rigidbody>();

        // ��� SpringJoint ���������
        SpringJoint joint = gameObject.AddComponent<SpringJoint>();
        joint.connectedBody = heavyObject;
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = Vector3.zero;
        joint.minDistance = 0f;
        joint.maxDistance = 5f;
        joint.spring = 10f; // ����ǿ��
        joint.damper = 0.5f; // ����ϵ��
        joint.minDistance = 0f; // ���ɵ���С����
    }

    void FixedUpdate()
    {
        // ʩ�����ϵĸ���
        balloonRigidbody.AddForce(Vector3.up * liftForce, ForceMode.Force);

        balloonRigidbody.AddForce(-new Vector3(balloonRigidbody.velocity.x, 0, balloonRigidbody.velocity.z),ForceMode.Force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ballon_wall"))
        {
            Destroy(gameObject);
        }
    }
    
}
