using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public Rigidbody heavyObject; // 重物的刚体
    public float liftForce = 10f; // 气球的浮力

    public float acceleration = 10f;

    private Rigidbody balloonRigidbody;


    private void Start()
    {
        balloonRigidbody = GetComponent<Rigidbody>();
    }

    public void Combine(Rigidbody heavyObject)
    {
        balloonRigidbody = GetComponent<Rigidbody>();

        // 添加 SpringJoint 组件并配置
        SpringJoint joint = gameObject.AddComponent<SpringJoint>();
        joint.connectedBody = heavyObject;
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = Vector3.zero;
        joint.minDistance = 0f;
        joint.maxDistance = 5f;
        joint.spring = 10f; // 弹簧强度
        joint.damper = 0.5f; // 阻尼系数
        joint.minDistance = 0f; // 弹簧的最小距离
    }

    void FixedUpdate()
    {
        // 施加向上的浮力
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
