using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private float _collectableYOffset = 1f, _explosionYOffset = 1f;
    private enum CollectableType
    {
        Coin,
        Health, Count
    }

    public void SpawnCollectable(Vector3 position)
    {
        int index = Random.Range(0, (int)CollectableType.Count - 1);
        CollectableType type = (CollectableType)index;
        GameObject collectable = null;
        switch (type)
        {
            case CollectableType.Coin:
                collectable = ObjectPool.instance.GetCoin();
                break;
        }
        if (collectable != null)
        {
            collectable.transform.position = new Vector3(position.x, _collectableYOffset, position.z);
            collectable.SetActive(true);
        }

    }

    public void SpawnExplosion(Vector3 position)
    {
        GameObject explosion = ObjectPool.instance.GetExplosion();
        explosion.transform.position = new Vector3(position.x, position.y + _explosionYOffset, position.z);
        explosion.SetActive(true);
        if (explosion.TryGetComponent<Explosion>(out var _explosionComponent))
        {
            _explosionComponent.ExplodeRoutine();
        }

    }
}
