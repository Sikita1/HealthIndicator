using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthDisplaySlider : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider _slider;

    private Coroutine _coroutine;

    private float _delay = 0.02f;

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

        _coroutine = StartCoroutine(SlideDisplay(health));

        _text.text = $"Çהמנמגüו: {health}%";
    }

    private IEnumerator SlideDisplay(float health)
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, 1f);
            yield return wait;
        }
    }
}
