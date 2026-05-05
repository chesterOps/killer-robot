using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Explosion : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }
    public void ExplodeRoutine()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        _particleSystem.Play();
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }
}
