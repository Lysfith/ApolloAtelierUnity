using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody;
    
    void Start()
    {

    }


    void Update()
    {
        transform.forward = Rigidbody.linearVelocity;
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
