using UnityEngine;

[RequireComponent(typeof(ICollectableBehaviour))]
public class Collectable : MonoBehaviour
{
    private ICollectableBehaviour _collectableBehaviour;

    void Awake()
    {
        _collectableBehaviour = GetComponent<ICollectableBehaviour>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            _collectableBehaviour.OnCollected(playerController.gameObject);
            gameObject.SetActive(false);
        }
    }
}
