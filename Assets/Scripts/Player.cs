using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Button _applyDamage;
    [SerializeField] private Button _treat;

    public event UnityAction<float> ChangedHealth;
    
    private float _health = 50f;
    private float _maxHealth = 100f;
    private float _minHealth = 0f;

    private float _damage = 10f;
    private float _treatment = 10f;

    private void Start()
    {
        ChangedHealth?.Invoke(_health);
    }

    public void OnClickButtonDamage()
    {
        _health -= _damage;

        if (_health < _minHealth)
            _health = _minHealth;

        ChangedHealth?.Invoke(_health);
    }

    public void OnClickButtonTreat()
    {
        _health += _treatment;

        if (_health > _maxHealth)
            _health = _maxHealth;

        ChangedHealth?.Invoke(_health);
    }
}
