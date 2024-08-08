using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _treatmentButton;
    [SerializeField] private Health _health;

    public event UnityAction<float> ChangedHealth;

    private float _damage = 10f;
    private float _treatment = 10f;

    private void OnEnable()
    {
        _treatmentButton.onClick.AddListener(TakeTreatment);
        _damageButton.onClick.AddListener(TakeDamage);
    }

    private void OnDisable()
    {
        _treatmentButton.onClick.RemoveListener(TakeTreatment);
        _damageButton.onClick.RemoveListener(TakeDamage);
    }

    private void Start()
    {
        ChangedHealth?.Invoke(_health.Current);
    }

    private void TakeDamage()
    {
        _health.TakeDamage(_damage);

        ChangedHealth?.Invoke(_health.Current);
    }

    private void TakeTreatment()
    {
        _health.Increase(_treatment);

        ChangedHealth?.Invoke(_health.Current);
    }
}
