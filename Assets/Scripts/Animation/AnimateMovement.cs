using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMovement : MonoBehaviour
{
    [SerializeField] private MovementStateExposer _movState;
    [SerializeField] private string _speedParameterName;

    private Animator _animator;
    private int _speedHash;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _speedHash = Animator.StringToHash(_speedParameterName);
    }

    private void LateUpdate()
    {
        _animator.SetFloat(_speedHash, _movState.RelativeVelocity.magnitude);
    }
}
