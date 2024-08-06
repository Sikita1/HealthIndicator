using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthDisplaySlider : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider _firstSlider;
    [SerializeField] private Slider _secondSlider;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private float _delay = 0.02f;
    private float _maxDelta = 1f;

    private void OnEnable()
    {
        _player.ChangedHealth += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothSliderChange(health));
        SliderChange(health);

        if (_text != null)
            _text.text = $"Çהמנמגüו: {health}%";
    }

    private void SliderChange(float health)
    {
        _secondSlider.value = health;
    }

    private IEnumerator SmoothSliderChange(float health)
    {
        _wait = new WaitForSeconds(_delay);

        while (_firstSlider.value != health)
        {
            _firstSlider.value = Mathf.MoveTowards(_firstSlider.value, health, _maxDelta);
            yield return _wait;
        }
    }
}
