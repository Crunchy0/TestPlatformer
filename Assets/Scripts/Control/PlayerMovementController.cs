using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MovementController
{
    public override Vector2 Direction { get => _joystick.Direction; }

    [SerializeField] protected Joystick _joystick;
}
