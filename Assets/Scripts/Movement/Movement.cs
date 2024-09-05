using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MaxSpeed { get => _maxSpeed; }
    public float Acceleration { get => _acceleration; }

    [SerializeField] private MovementController _controller;
    [SerializeField] private Transform _camTransform;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _acceleration;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float percent = _rigidbody.velocity.magnitude / _maxSpeed;
        if (percent - 1 > 1e-3)
            _rigidbody.velocity /= percent;

        Vector3 forward = _camTransform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 dir = _controller.Direction.y * forward + _controller.Direction.x * _camTransform.right;
        if (dir.magnitude < 1e-3 || percent >= 1)
            return;

        _rigidbody.AddForce(dir * _acceleration * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
