using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
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

    public void ChangeTarget()
    {
        _target = _player.Health;

        StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        while (_slider.value != _target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _target, _speed * Time.deltaTime);

            yield return null;
        }
    }
}