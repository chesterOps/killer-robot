using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> _bullets = new();
    private List<GameObject> _coins = new();
    private List<GameObject> _explosions = new();
    [SerializeField] private int _coinCount = 10, _bulletCount = 10, _explosionCount = 4;
    [SerializeField] private GameObject _bulletPrefab, _coinPrefab, _explosionPrefab;

    void Awake()
    {
        // Singleton pattern implementation
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Pre-instantiate bullets
        for (int i = 0; i < _bulletCount; i++)
        {
            CreateObject(_bulletPrefab, _bullets);
        }
        // Pre-instantiate coins
        for (int i = 0; i < _coinCount; i++)
        {
            CreateObject(_coinPrefab, _coins);
        }
        // Pre-instantiate _explosions
        for (int i = 0; i < _explosionCount; i++)
        {
            CreateObject(_explosionPrefab, _explosions);
        }
    }

    private GameObject CreateObject(GameObject prefab, List<GameObject> container)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.parent = transform;
        obj.SetActive(false);
        container.Add(obj);
        return obj;
    }

    private GameObject GetObject(GameObject prefab, List<GameObject> container)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (!container[i].activeInHierarchy)
            {
                return container[i];
            }
        }
        return CreateObject(prefab, container);
    }



    public GameObject GetBullet()
    {
        return GetObject(_bulletPrefab, _bullets);
    }

    public GameObject GetCoin()
    {
        return GetObject(_coinPrefab, _coins);
    }

    public GameObject GetExplosion()
    {
        return GetObject(_explosionPrefab, _explosions);
    }


}
