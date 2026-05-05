using UnityEngine;

public class EnemyCollectableDrop : MonoBehaviour
{
    [SerializeField] private float _chanceOfCollectableDrop;
    private Spawner _spawner;

    void Awake()
    {
        _spawner = FindAnyObjectByType<Spawner>();
    }

    public void RandomlyDropCollectable()
    {
        float randomFloat = Random.Range(0f, 1f);

        if (_chanceOfCollectableDrop >= randomFloat)
        {
            _spawner.SpawnCollectable(transform.position);
        }

    }
}
