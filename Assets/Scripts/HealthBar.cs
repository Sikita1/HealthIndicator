using UnityEngine;
using UnityEngine.UI;

public class HealthBar : SliderDisplay
{
    [SerializeField] private Slider _slider;

    protected override void OnHealthChanged(float health)
    {
        _slider.value = health;
    }
}
