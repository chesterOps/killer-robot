using UnityEngine;


public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _bulletSpeed;
    private PlayerInputController _playerInputController;

    void Awake()
    {
        _playerInputController = FindAnyObjectByType<PlayerInputController>();
        _playerInputController.OnAttackButtonPressed += Shoot;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        if (bullet.TryGetComponent<Rigidbody>(out var bulletRigidbody))
        {
            bulletRigidbody.linearVelocity = -transform.up * _bulletSpeed;
        }
    }
}
