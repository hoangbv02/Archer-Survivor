using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JoystickHandler : MonoBehaviour
{
    [SerializeField] Joystick _joystick;
    public Vector3 GetJoystickDirection => new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
}
