using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(LineRenderer),typeof(SpringJoint))]
public class Balloon : MonoBehaviour
{
    private Rigidbody heavyObject;
    private LineRenderer m_lineRenderer;
    private SpringJoint m_joint;

    private LineRenderer lineRenderer
    {
        get
        {
            if (m_lineRenderer == null)
                m_lineRenderer = GetComponent<LineRenderer>();
            return m_lineRenderer;
        }
    }
    private SpringJoint joint
    {
        get
        {
            if (m_joint == null)
                m_joint = GetComponent<SpringJoint>();
            return m_joint;
        }
    }

    public float liftForce = 10f; // 气球的浮力

    public float acceleration = 10f;

    private Rigidbody m_rigidbody;

    private Rigidbody balloonRigidbody
    {
        get
        {
            if(m_rigidbody == null)
                m_rigidbody=GetComponent<Rigidbody>();
            return m_rigidbody;
        }
    }

    public void Combine(Rigidbody heavyObject,float maxDistance = 5f)
    {
        // 添加 SpringJoint 组件并配置
        this.heavyObject = heavyObject;
        joint.connectedBody = heavyObject;
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = Vector3.zero;
        joint.minDistance = 0f;
        joint.maxDistance = 5f;
        joint.spring = 10f; // 弹簧强度
        joint.damper = 0.5f; // 阻尼系数
        joint.minDistance = 0f; // 弹簧的最小距离
    }


    private void Update()
    {
        if (heavyObject == null) return;
        lineRenderer.SetPositions(new Vector3[] { transform.position, heavyObject.transform.position });
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
            BalloonPool.Instance.Return(this);
        }
    }

    public void ResetState()
    {
        heavyObject = null;
        if(joint != null) 
            joint.connectedBody = null;
    }
    
}
