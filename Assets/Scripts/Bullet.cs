using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _lifetime = 5f;

    void Start()
    {

        StartCoroutine(DestroyCoroutine());
    }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        collision.gameObject.SetActive(false);
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(_lifetime);
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}