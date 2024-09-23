using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float ExplosionForce;
    public float ExplosionRadius;

    private bool _deathAsked = false;
    
    void Start()
    {

    }


    void Update()
    {
        if(_deathAsked)
        {
            return;
        }

        transform.forward = Rigidbody.linearVelocity;
    }

    private void OnCollisionEnter(Collision other) {
        if(_deathAsked)
        {
            return;
        }

        StartCoroutine(WaitDeath(5));

        //other.collider.GetComponent<Rigidbody>().AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);

        
    }

    IEnumerator WaitDeath(float seconds)
    {
        _deathAsked = true;
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
