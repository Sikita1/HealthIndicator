using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : SliderDisplay
{
    [SerializeField] private Slider _slider;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private float _delay = 0.02f;
    private float _maxDelta = 1f;

    protected override void OnHealthChanged(float health)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothSliderChange(health));
    }

    private IEnumerator SmoothSliderChange(float health)
    {
        _wait = new WaitForSeconds(_delay);

        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _maxDelta);
            yield return _wait;
        }
    }
}
