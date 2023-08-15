using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _healPoints = 10f;
    [SerializeField] private float _speed = 0.5f;

    private bool _isRunning = false;
    private int _converter = 100;    

    public void TakeGamage(float damage)
    {
        if (_isRunning == false)
            StartCoroutine(TakeAwayHealth(damage));
    }

    public void Heal()
    {
        if (_isRunning == false)
            StartCoroutine(AddHealth());        
    }

    private IEnumerator TakeAwayHealth(float damage)
    {
        float targetValue;

        _isRunning = true;
        targetValue = _slider.value - damage / _converter;
        targetValue = targetValue >= _slider.minValue ? targetValue : _slider.minValue;       

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }

        _isRunning = false;
    }

    private IEnumerator AddHealth()
    {
        float targetValue;

        _isRunning = true;
        targetValue = _slider.value + _healPoints / _converter;
        targetValue = targetValue <= _slider.maxValue ? targetValue : _slider.maxValue;

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }

        _isRunning = false;
    }
}
