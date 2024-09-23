using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameManager GameManager;

    private List<long> _wallIds;

    void Start()
    {
        _wallIds = new List<long>();
    }
    
    private void OnCollisionEnter(Collision other) {
        
        if(other.collider.gameObject.tag == "Wall" && !_wallIds.Contains(other.collider.gameObject.GetInstanceID()))
        {
            _wallIds.Add(other.collider.gameObject.GetInstanceID());
            GameManager.AddScore(1);
            return;
        }
    }
}
