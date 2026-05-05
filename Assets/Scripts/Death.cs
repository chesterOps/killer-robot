using UnityEngine;

public class Death : MonoBehaviour
{
    private Spawner _spawner;

    void Awake()
    {
        _spawner = FindAnyObjectByType<Spawner>();
    }

    public void DeathExplosion()
    {
        _spawner.SpawnExplosion(transform.position);
    }

}
