using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Composant qui gère les projectiles du cannon
/// </summary>
public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody;

    private bool _hasCollide = false;
    
    void Update()
    {
        if(_hasCollide)
        {
            return;
        }

        transform.forward = Rigidbody.linearVelocity;
    }

    private void OnCollisionEnter(Collision other) {
        _hasCollide = true;
    }
}
