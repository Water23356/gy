using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    public float jumpForce = 8f;

    private float timer = 0f;

    private int jumpTimes = 1;

    public JumpCheck check;


    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x,0,z);
        if(dir.magnitude > 0.1f)
        {
            var moveDir = transform.TransformDirection(dir.normalized) * speed;
            Debug.DrawLine(transform.position, transform.position + transform.forward);
            rigidbody.velocity = new Vector3(moveDir.x, rigidbody.velocity.y, moveDir.z);
        }
        else
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y,0);
        }
     
        if(Input.anyKey)
        {
            if(Input.GetKeyDown(KeyCode.Space) && jumpTimes > 0)
            {
                rigidbody.AddForce(Vector3.up* jumpForce, ForceMode.Impulse);
                timer = 0.2f;
                check.enabled = false;
                jumpTimes--;
            }
        }

        if(timer>0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            check.enabled = true;
        }
    }

    public void ResetJumpTimes()
    {
        jumpTimes = 1;
    }

}
