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
    private void Update()
    {
        CapVelocity();
    }
    void Bounce(Vector3 surfacePos)
    {
        Vector3 desiredVelocity = m_Rigidbody.velocity *-10;




        if (Mathf.Abs(surfacePos.x - transform.position.x) > 3)
        {
            desiredVelocity.y += UnityEngine.Random.Range(-4.5f, 4.5f);
        }

        if (Mathf.Abs(surfacePos.y - transform.position.y) > 3)
        {
            desiredVelocity.x += UnityEngine.Random.Range(-4.5f, 4.5f);
        }










        desiredVelocity.z = 0;

        m_Rigidbody.velocity = desiredVelocity;
        CapVelocity();

    

    }

    private void CapVelocity()
    {
        Vector3 desiredVelocity = m_Rigidbody.velocity;
        float maxVelocity = 1.5f;






        if (desiredVelocity.x > maxVelocity)
        {
            desiredVelocity.x = maxVelocity;
        }
        else if (desiredVelocity.x < -maxVelocity)
        {
            desiredVelocity.x = -maxVelocity;
        }
        else if (desiredVelocity.x != 0 && Mathf.Abs(desiredVelocity.x) < 1.0f)
        {
            if (desiredVelocity.x > 0)
            {
                desiredVelocity.x = 1;
            }
            else
            {
                desiredVelocity.x = -1;
            }
        }


        if (desiredVelocity.y > maxVelocity)
        {
            desiredVelocity.y = maxVelocity;
        }
        else if (desiredVelocity.y < -maxVelocity)
        {
            desiredVelocity.y = -maxVelocity;
        }
        else if (desiredVelocity.y!= 0 && Mathf.Abs(desiredVelocity.y) < 1.0f)
        {
            if (desiredVelocity.y > 0)
            {
                desiredVelocity.y= 1;
            }
            else
            {
                desiredVelocity.y= -1;
            }
        }







        if ( desiredVelocity != m_Rigidbody.velocity)
        {
            m_Rigidbody.velocity = desiredVelocity;
        }

    }


    private void OnCollisionEnter(Collision other)
    {
        Bounce(other.gameObject.transform.position);
       
    }
}
