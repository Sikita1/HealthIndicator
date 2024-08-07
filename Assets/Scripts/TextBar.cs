using TMPro;
using UnityEngine;

public class TextBar : SliderDisplay
{
    [SerializeField] private TMP_Text _text;

    protected override void OnHealthChanged(float health)
    {
        _text.text = $"Çהמנמגüו: {health}%";
    }
}
