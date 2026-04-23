using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> _bullets = new();
    [SerializeField] private int bulletCount = 20;
    [SerializeField] private GameObject _bullet;

    void Awake()
    {
        // Singleton pattern implementation
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // Pre-instantiate bullets and add them to the pool
        for (int i = 0; i < bulletCount; i++)
        {
            CreateBullet();
        }
    }

    GameObject CreateBullet()
    {
        GameObject obj = Instantiate(_bullet);
        obj.transform.parent = transform;
        obj.SetActive(false);
        _bullets.Add(obj);
        return obj;
    }


    public GameObject GetBullet()
    {
        // Retrieve an inactive bullet from the pool
        for (int i = 0; i < _bullets.Count; i++)
        {
            if (!_bullets[i].activeInHierarchy)
            {
                return _bullets[i];
            }
        }

        GameObject newBullet = CreateBullet();
        return newBullet; // If no inactive bullets are available, instantiate a new one
    }
}
