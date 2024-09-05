using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAlongVelocity : MonoBehaviour
{
    [SerializeField] private MovementStateExposer _movState;

    void Update()
    {
        Vector3 velProjection = Vector3.ProjectOnPlane(_movState.Direction, transform.up);
        float angle = Vector3.SignedAngle(transform.forward, velProjection, transform.up);
        transform.Rotate(transform.up, angle);
    }
}
