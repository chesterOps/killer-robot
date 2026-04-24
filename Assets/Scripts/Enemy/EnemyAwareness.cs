using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector3 DirectionToPlayer { get; private set; }
    [SerializeField] float _playerAwarenessDistance;

    private Transform _player;
    void Awake()
    {
        _player = FindAnyObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 enemyToPlayerVector = _player.position - transform.position;
        enemyToPlayerVector.y = 0f;
        DirectionToPlayer = enemyToPlayerVector.normalized;
        AwareOfPlayer = enemyToPlayerVector.magnitude <= _playerAwarenessDistance;
    }
}
