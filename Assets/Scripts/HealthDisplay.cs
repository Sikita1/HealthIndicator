using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ChangedHealth += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= OnHealthChanged;
    }

    protected virtual void OnHealthChanged(float health) { }
}