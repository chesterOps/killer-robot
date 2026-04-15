using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private Vector3 _newMovement;
    private CharacterController _characterController;
    [SerializeField] float _movementSpeed;
    [SerializeField] float _rotationSpeed;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        _newMovement = new(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(_newMovement.magnitude) * _movementSpeed;
        _newMovement.Normalize();
        _characterController.SimpleMove(_newMovement * magnitude);

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
