using UnityEngine;

public class Health : MonoBehaviour
{
    private float _currentValue = 50f;
    private float _maxValue = 100f;

    public float Current => _currentValue;

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        _currentValue = Mathf.Max(_currentValue - damage, 0);
    }

    public void Increase(float life)
    {
        if (life < 0)
            return;

        _currentValue = Mathf.Min(_currentValue + life, _maxValue);
    }
}
