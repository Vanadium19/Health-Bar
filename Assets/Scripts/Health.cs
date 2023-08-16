using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healPoints = 10f;
    [SerializeField] private UnityEvent _healthChanged = new UnityEvent();

    private float _maxHealth = 100f;
    private float _minHealth = 0f;
    private float _currentHealth;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    public event UnityAction HealthChanged
    {
        add => _healthChanged.AddListener(value);
        remove => _healthChanged.RemoveListener(value);
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = _currentHealth >= _minHealth ? _currentHealth : _minHealth;
        _healthChanged.Invoke();
    }

    public void Heal()
    {
        _currentHealth += _healPoints;
        _currentHealth = _currentHealth <= _maxHealth ? _currentHealth : _maxHealth;
        _healthChanged.Invoke();
    }
}
