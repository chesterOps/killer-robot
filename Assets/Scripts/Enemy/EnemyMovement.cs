using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyAwareness))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed, _rotationSpeed;
    private Rigidbody _rigidBody;
    private EnemyAwareness _enemyAwareness;
    private Vector3 _targetDirection;
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _enemyAwareness = GetComponent<EnemyAwareness>();

    }

    void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_enemyAwareness.AwareOfPlayer)
            _targetDirection = _enemyAwareness.DirectionToPlayer;
        else
            _targetDirection = Vector3.zero;
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_targetDirection, Vector3.up);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _rigidBody.MoveRotation(rotation);
        }

    }

    private void SetVelocity()
    {
        if (_targetDirection.sqrMagnitude < 0.001f)
            _rigidBody.linearVelocity = Vector3.zero;
        else
            _rigidBody.linearVelocity = _targetDirection * _speed;
    }
}
