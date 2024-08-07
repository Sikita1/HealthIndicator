using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _treatmentButton;

    public event UnityAction<float> ChangedHealth;
    
    private float _health = 50f;
    private float _maxHealth = 100f;
    private float _minHealth = 0f;

    private float _damage = 10f;
    private float _treatment = 10f;

    private void OnEnable()
    {
        _treatmentButton.onClick.AddListener(Heal);
        _damageButton.onClick.AddListener(TakeDamage);
    }

    private void OnDisable()
    {
        _treatmentButton.onClick.RemoveListener(Heal);
        _damageButton.onClick.RemoveListener(TakeDamage);
    }

    private void Start()
    {
        ChangedHealth?.Invoke(_health);
    }

    private void TakeDamage()
    {
        _health -= _damage;

        if (_health < _minHealth)
            _health = _minHealth;

        ChangedHealth?.Invoke(_health);
    }

    private void Heal()
    {
        _health += _treatment;

        if (_health > _maxHealth)
            _health = _maxHealth;

        ChangedHealth?.Invoke(_health);
    }
}
