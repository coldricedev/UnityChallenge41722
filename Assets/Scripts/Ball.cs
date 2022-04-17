using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionExit(Collision other)
    {


        var velocity = m_Rigidbody.velocity;




        
        //after a collision we accelerate a bit
        velocity += velocity.normalized * 0.01f;



        m_Rigidbody.velocity = velocity;
    }
}
