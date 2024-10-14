using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiFloat : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (rb.velocity.y > 0)
        {
            AntiFloatForce();
        }
        else
        {
            StopForce();
        }

    }

    void AntiFloatForce()
    {
        rb.drag = rb.velocity.magnitude;
    }

    void StopForce()
    {
        rb.drag = 0;
    }
}
