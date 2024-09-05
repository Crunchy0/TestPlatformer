using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateExposer : MonoBehaviour
{
    public float CurrentSpeed { get => _rigidbody.velocity.magnitude; }
    public Vector2 RelativeVelocity { get => _relVel; }
    public Vector3 Direction { get => _rigidbody.velocity.normalized; }

    private Rigidbody _rigidbody;
    private Movement _movement;
    private Vector2 _relVel = Vector2.zero;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        float percent = CurrentSpeed / _movement.MaxSpeed;

        float angle = Vector3.SignedAngle(transform.forward, _rigidbody.velocity, transform.up);
        float radAngle = angle * Mathf.Deg2Rad;

        _relVel.x = Mathf.Sin(radAngle);
        _relVel.y = Mathf.Cos(radAngle);
        _relVel *= percent;
    }
}
