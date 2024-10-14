using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AntiFloat : MonoBehaviour
{
    public Rigidbody rb;

    private Vector3 originPos;

    public float limitOffset = 50.0f;

    private float offset = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (rb.velocity.y > 0)
        {

        }
        else
        {

        }

        offset = transform.position.y - originPos.y;


        if (offset > 5)
        {
            rb.AddForce(Vector3.down * (120.0f + offset * 10));
        }
        else if (offset < (-1 * limitOffset))
        {
            rb.AddForce(Vector3.up * 48.0f);
        }
    }

    void AntiFloatForce()
    {
        rb.drag = rb.velocity.magnitude * 2 + 5;
    }

    void StopForce()
    {
        rb.drag = 0;
    }
}
