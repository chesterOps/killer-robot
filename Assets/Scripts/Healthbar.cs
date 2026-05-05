using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Healthbar : MonoBehaviour
{
    private Image _healthBarImage;
    void Awake()
    {
        _healthBarImage = GetComponent<Image>();
    }

    public void UpdateHealthBar(GameObject player)
    {
        if (player.TryGetComponent<HealthController>(out var healthController))
        {
            _healthBarImage.fillAmount = healthController.RemainingHealthPercentage;
        }
    }
}
