using UnityEngine;

public class Shoot : MonoBehaviour
{
    protected void FireBullet(Transform transform)
    {
        GameObject bullet = ObjectPool.instance.GetBullet();
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
        bullet.SetActive(true);
        if (bullet.TryGetComponent<Bullet>(out var _bullet))
        {
            _bullet.DestroyBulletRoutine();
        }
    }
}
