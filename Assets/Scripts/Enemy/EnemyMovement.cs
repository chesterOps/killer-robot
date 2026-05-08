using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyAwareness))]

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed, _rotationSpeed;
    [SerializeField] private Vector3[] _patrolPoints;
    private int _targetPatrolPoint = 0;
    private Rigidbody _rigidBody;
    private CapsuleCollider _capsuleCollider;
    private bool _isGrounded;
    private float _groundCheckDistance;
    private float _bufferCheckDistance = 0.1f;

    private EnemyAwareness _enemyAwareness;
    private Vector3 _targetDirection;
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _enemyAwareness = GetComponent<EnemyAwareness>();
        if (_patrolPoints.Length > 0)
        {
            _targetDirection = _patrolPoints[_targetPatrolPoint];
        }
        else
        {
            _targetDirection = transform.position;
        }
    }



    void FixedUpdate()
    {
        SetIsGrounded();
        if (_isGrounded)
        {
            UpdateTargetDirection();
            RotateTowardsTarget();
            SetVelocity();
        }
    }

    private void SetIsGrounded()
    {
        _groundCheckDistance = _capsuleCollider.height / 2 * _bufferCheckDistance;
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, _groundCheckDistance))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private void UpdateTargetDirection()
    {
        if (_enemyAwareness.AwareOfPlayer)
            _targetDirection = _enemyAwareness.DirectionToPlayer;
        else
        {
            HandlePatrolDirection();
        }
    }

    private void HandlePatrolDirection()
    {
        if (_patrolPoints.Length == 0) return;

        if (transform.position == _patrolPoints[_targetPatrolPoint])
        {
            _targetPatrolPoint++;
            if (_targetPatrolPoint >= _patrolPoints.Length)
            {
                _targetPatrolPoint = 0;
            }
        }
        _targetDirection = _patrolPoints[_targetPatrolPoint];
    }


    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_targetDirection, Vector3.up);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        _rigidBody.MoveRotation(rotation);
    }

    private void SetVelocity()
    {
        if (_enemyAwareness.AwareOfPlayer)
        {
            _rigidBody.linearVelocity = Vector3.zero;
            return;
        }
        if (transform.position != _targetDirection) _rigidBody.linearVelocity = transform.forward * _speed;
    }
}
