using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInputController))]
public class PlayerController : MonoBehaviour
{
    private Vector3 _newMovement;
    private PlayerInputController _playerInputController;
    private CharacterController _characterController;
    private bool _isJumpTriggered = false;
    private float _ySpeed;
    [SerializeField] GameObject _legs;
    [SerializeField] float _movementSpeed;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _jumpSpeed;


    void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
        _characterController = GetComponent<CharacterController>();
        _playerInputController.OnJumpButtonPressed += JumpPressed;
    }

    // Update is called once per frame
    void Update()
    {

        RotateLegs();
        MovePlayer();
        RotatePlayer();

    }

    void RotateLegs()
    {
        if (_playerInputController.MovementDirectionVector != Vector3.zero)
        {
            _legs.transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.right, Space.Self);
        }
    }


    void MovePlayer()
    {
        _newMovement = _playerInputController.MovementDirectionVector * _movementSpeed;
        _ySpeed += Physics.gravity.y * Time.deltaTime;
        if (_isJumpTriggered == true)
        {
            _ySpeed = _jumpSpeed;
            _isJumpTriggered = false;
        }
        _newMovement.y = _ySpeed;
        _characterController.Move(_newMovement * Time.deltaTime);
    }

    void RotatePlayer()
    {
        Vector3 horizontalMovement = new(_newMovement.x, 0, _newMovement.z);
        if (horizontalMovement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(horizontalMovement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    void JumpPressed()
    {
        if (_characterController.isGrounded)
        {
            _isJumpTriggered = true;
        }
    }


}
