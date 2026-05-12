using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    private LevelManager _levelManager;

    void Awake()
    {
        _levelManager = FindAnyObjectByType<LevelManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out var _player) && _levelManager != null)
        {
            _levelManager.LoadScene();
        }
    }
}
