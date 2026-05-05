using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float _damageAmount = 20, _bulletSpeed = 35f, _lifetime = 5f;
    private Rigidbody _rigidBody;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        _rigidBody.linearVelocity = transform.forward * _bulletSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        if (other.gameObject.TryGetComponent<HealthController>(out var healthController))
        {
            healthController.TakeDamage(_damageAmount);
        }
    }

    public void DestroyBulletRoutine()
    {
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(_lifetime);
        gameObject.SetActive(false);
    }
}