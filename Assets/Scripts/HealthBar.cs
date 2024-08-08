using UnityEngine.UI;

public class HealthBar : SliderView
{
    protected override void OnHealthChanged(float health)
    {
        Slider.value = health;
    }
}
