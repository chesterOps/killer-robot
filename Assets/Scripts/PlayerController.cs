using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInputController))]
public class PlayerController : MonoBehaviour
{
    private Vector3 _newMovement;
    private PlayerInputController _playerInputController;
    private CharacterController _characterController;
    [SerializeField] float _movementSpeed;
    [SerializeField] float _rotationSpeed;


    void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        _newMovement = _playerInputController.MovementDirectionVector;
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
