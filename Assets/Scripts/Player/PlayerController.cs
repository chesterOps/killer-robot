using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInputController))]
public class PlayerMovement : MonoBehaviour
{
    private Vector3 _newMovement;
    private CharacterController _characterController;
    private PlayerInputController _playerInputController;
    [SerializeField] float _movementSpeed;
    [SerializeField] float _rotationSpeed;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerInputController = GetComponent<PlayerInputController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {

        _newMovement = new(_playerInputController.MovementInputVector.x, 0, _playerInputController.MovementInputVector.y);
        _characterController.SimpleMove(_newMovement * _movementSpeed);
    }

    void RotatePlayer()
    {
        if (_newMovement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_newMovement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
