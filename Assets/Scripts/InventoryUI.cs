using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class InventoryUI : MonoBehaviour
{
    private TMP_Text _coinCountText;

    void Start()
    {
        _coinCountText = GetComponent<TMP_Text>();
    }

    public void UpdateCoinText(PlayerInventory playerInventory)
    {
        _coinCountText.text = playerInventory.NumberOfCoins.ToString();
    }
}
