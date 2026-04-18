using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector3 MovementDirectionVector { get; private set; }
    public event Action OnJumpButtonPressed;

    void OnMove(InputValue inputValue)
    {
        Vector2 direction = inputValue.Get<Vector2>();
        MovementDirectionVector = new(direction.x, 0, direction.y);
    }

    void OnJump(InputValue inputvalue)
    {
        if (inputvalue.isPressed)
        {
            OnJumpButtonPressed?.Invoke();
        }
    }
}
