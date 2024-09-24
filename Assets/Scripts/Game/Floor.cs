using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Composant qui permet de détecter quand une cible tombe sur le sol
/// </summary>
public class Floor : MonoBehaviour
{
    public GameManager GameManager;

    private List<long> _targetIds;

    void Start()
    {
        _targetIds = new List<long>();
    }
    
    private void OnCollisionEnter(Collision other) {
        
        if(other.collider.gameObject.tag == "Target" && !_targetIds.Contains(other.collider.gameObject.GetInstanceID()))
        {
            var rb = other.collider.gameObject.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
            _targetIds.Add(other.collider.gameObject.GetInstanceID());
            GameManager.AddScore(1);
            return;
        }
    }
}
