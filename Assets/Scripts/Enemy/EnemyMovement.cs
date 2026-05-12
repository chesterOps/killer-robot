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
    public Vector3 _targetDirection;
    private float DirectionEpsilon = 0.001f;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _enemyAwareness = GetComponent<EnemyAwareness>();
        if (_patrolPoints.Length > 0)
            _targetDirection = CalculateTargetDirection(_patrolPoints[_targetPatrolPoint]);

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

    private Vector3 CalculateTargetDirection(Vector3 destination)
    {
        Vector3 relPos = destination - transform.position;
        return _targetDirection = new Vector3(relPos.x, 0, relPos.z).normalized;
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
        {

            _targetDirection = _enemyAwareness.DirectionToPlayer;
        }
        else
        {
            HandlePatrolDirection();
        }
    }

    private void HandlePatrolDirection()
    {
        if (_patrolPoints.Length == 0)
        {

            return;
        }
        Vector3 point = _patrolPoints[_targetPatrolPoint];
        Vector3 toPoint = point - transform.position;
        toPoint.y = 0;

        if (toPoint.sqrMagnitude <= 0.01f)
        {
            _targetPatrolPoint++;
            if (_targetPatrolPoint >= _patrolPoints.Length)
            {
                _targetPatrolPoint = 0;
            }
            point = _patrolPoints[_targetPatrolPoint];
            toPoint = point - transform.position;
            toPoint.y = 0;
        }

        _targetDirection = toPoint.normalized;
    }


    private void RotateTowardsTarget()
    {
        if (_targetDirection.sqrMagnitude <= DirectionEpsilon)
        {

            return;
        }
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
        if (_targetDirection.sqrMagnitude > DirectionEpsilon)
        {
            _rigidBody.linearVelocity = transform.forward * _speed;
        }
    }
}
