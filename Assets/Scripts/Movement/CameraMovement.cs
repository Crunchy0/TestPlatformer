using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _spot;

    private void LateUpdate()
    {
        transform.position = _spot.position;
    }
}
