using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent Dead;
    [SerializeField] private UnityEvent ChangedHealth;

    private float _maxHealth = 100;
    private float _healthStep = 10;
    private float _health;

    public float MaxHealth => _maxHealth;
    public float Health => _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void Heal()
    {
        if (_health + _healthStep <= _maxHealth)
        {
            _health += _healthStep;
        }
        else
        {
            float deltaHealth = _maxHealth - _health;

            _health += deltaHealth;
        }

        ChangedHealth?.Invoke();
    }

    public void TakeDamage()
    {
        if (_health - _healthStep >= 0)
        {
            _health -= _healthStep;
        }
        else
        {
            _health -= _health;
        }

        ChangedHealth?.Invoke();

        if (_health == 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        Dead?.Invoke();
    }
}