using UnityEngine;

public class SliderDisplay : MonoBehaviour
{
    [SerializeField] protected Player Player;

    private void OnEnable()
    {
        Player.ChangedHealth += OnHealthChanged;
    }

    private void OnDisable()
    {
        Player.ChangedHealth -= OnHealthChanged;
    }

    protected virtual void OnHealthChanged(float health) { }
}