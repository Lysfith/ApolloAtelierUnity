using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Composant qui gère le canon.
/// </summary>
public class Turret : MonoBehaviour
{
    public float AngleMax = -50;
    public float AngleMin = 0;
    public float Speed = 10;
    public float PowerMultiplier = 10;
    public Transform Cannon;
    public Transform ShootPoint;
    public GameObject BulletPrefab;
    public ParticleSystem ParticleSystem;
    public AudioSource AudioSource;

    private float _angle;
    private bool _goUp;
    private Quaternion _rotationBase;

    private bool _angleSelection;
    
    void Start()
    {
        _rotationBase = Cannon.transform.rotation;
        BulletPrefab.SetActive(false);
        ParticleSystem.Pause();
    }


    void Update()
    {
        if(!_angleSelection)
        {
            return;
        }

        if (_angle < AngleMax)
        {
            _angle = AngleMax;
            _goUp = !_goUp;
        }
        else if (_angle > AngleMin)
        {
            _angle = AngleMin;
            _goUp = !_goUp;
        }

        _angle += (_goUp ? -1 : 1) * Speed * Time.deltaTime;

        Cannon.transform.rotation = _rotationBase * Quaternion.Euler(_angle, 0, 0);
    }

    public void StartAngleSelection()
    {
        _angle = 0;
        _angleSelection = true;
    }

    public void StopAngleSelection()
    {
        _angleSelection = false;
    }

    public void Shoot(float power)
    {
        var bullet = Instantiate(BulletPrefab);
        bullet.transform.position = ShootPoint.position;
        bullet.transform.forward = ShootPoint.forward;
        bullet.SetActive(true);

        var rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bullet.transform.forward * power * PowerMultiplier, ForceMode.Impulse);
        rb.useGravity = true;

        ParticleSystem.Play();
        AudioSource.Play();
    }
}
