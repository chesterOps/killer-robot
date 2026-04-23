using UnityEngine;


public class PlayerShoot : MonoBehaviour
{

    [SerializeField] float _bulletSpeed = 20f;
    private PlayerInputController _playerInputController;

    void Awake()
    {
        _playerInputController = FindAnyObjectByType<PlayerInputController>();
        _playerInputController.OnAttackButtonPressed += Shoot;
    }

    private void Shoot()
    {
        GameObject bullet = ObjectPool.instance.GetBullet();
        if (bullet.TryGetComponent<Rigidbody>(out var bulletRigidbody))
        {
            bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
            bullet.SetActive(true);
            bulletRigidbody.linearVelocity = transform.forward * _bulletSpeed;
        }
    }
}
