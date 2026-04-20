using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, _lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}