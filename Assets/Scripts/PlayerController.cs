using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    public float jumpForce = 8f;



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
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.AddForce(Vector3.up* jumpForce, ForceMode.Impulse);
            }
        }

    }

}
