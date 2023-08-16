using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarChanger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _heroHealth;
    [SerializeField] private float _speed = 0.5f;

    private Coroutine _healthChanger;

    private void OnEnable()
    {
        _heroHealth.HealthChanged += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _heroHealth.HealthChanged -= ChangeHealthBar;
    }

    private void ChangeHealthBar()
    {
        StopChangingHealthBar();
        StartChangingHealthBar();
    }

    private void StartChangingHealthBar()
    {
        _healthChanger = StartCoroutine(ChangeHealthBarValue());
    }

    private void StopChangingHealthBar()
    {
        if (_healthChanger != null)
            StopCoroutine(_healthChanger);
    }

    private IEnumerator ChangeHealthBarValue()
    {
        float targetValue = _heroHealth.CurrentHealth * _slider.maxValue / _heroHealth.MaxHealth;

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
