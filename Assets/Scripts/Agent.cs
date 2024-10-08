using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    public Rigidbody rigidbody
    {
        get
        {
            if(m_rigidbody == null)
                m_rigidbody = GetComponent<Rigidbody>();
            return m_rigidbody;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
