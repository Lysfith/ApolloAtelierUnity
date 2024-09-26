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
    public TrailRenderer TrailRenderer;

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
        if(_hasCollide)
        {
            return;
        }
        _hasCollide = true;
        TrailRenderer.gameObject.SetActive(false);
        StartCoroutine(WaitDeath(5));
    }

    IEnumerator WaitDeath(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log($"Bullet {gameObject.GetInstanceID()} destroyed !");
        Destroy(gameObject);
    }
}
