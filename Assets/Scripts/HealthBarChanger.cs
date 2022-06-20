using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarChanger : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;
    private float _target;
    private float _speed = 20f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.minValue = 0;
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.MaxHealth;
        _target = _player.MaxHealth;
    }

    private void Update()
    {
        _target = _player.Health;

        if (_player != null)
            _slider.value = Mathf.MoveTowards(_slider.value, _target, _speed * Time.deltaTime);
        else
            _slider.value = _slider.minValue;
    }
}