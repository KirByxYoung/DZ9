using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _healthStep = 10;
    private float _health;

    public float MaxHealth => _maxHealth;
    public float Health => _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        if (_health == 0)
            Dead();
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
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
