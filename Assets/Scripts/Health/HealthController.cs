using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _currentHealth, _maximumHealth;

    public UnityEvent OnDied;
    public UnityEvent OnDamaged;

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0) return;
        _currentHealth -= damageAmount;
        OnDamaged.Invoke();
        if (_currentHealth < 0) _currentHealth = 0;
        if (_currentHealth == 0) OnDied.Invoke();

    }

    public void AddHealth(float healthAmount)
    {
        if (_currentHealth == _maximumHealth) return;
        _currentHealth += healthAmount;
        if (_currentHealth > _maximumHealth) _currentHealth = _maximumHealth;
    }
}
