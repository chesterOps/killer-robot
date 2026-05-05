using UnityEngine;

public class CoinCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    public void OnCollected(GameObject player)
    {
        if (player.TryGetComponent<PlayerInventory>(out var playerInventory))
        {
            playerInventory.CoinCollected();
        }
    }
}
