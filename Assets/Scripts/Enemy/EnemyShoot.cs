using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyAwareness))]
public class EnemyShoot : Shoot
{
    [SerializeField] private GameObject _gun;
    private EnemyAwareness _enemyAwareness;


    void Awake()
    {
        _enemyAwareness = GetComponent<EnemyAwareness>();
    }

    void Start()
    {
        StartCoroutine(ShootPlayerRoutine());
    }

    IEnumerator ShootPlayerRoutine()
    {
        while (gameObject.activeInHierarchy)
        {
            if (_enemyAwareness.AwareOfPlayer)
            {
                yield return new WaitForSeconds(2f); ;
                FireBullet(_gun.transform);
            }
            yield return null;
        }
    }


}
