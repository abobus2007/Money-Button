using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockHealthView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countHeath;
    [SerializeField] private Scrollbar _healthBar;

    private float _maxHealth;

    public void UpdateHealthParametr(float healthToView)
    {
        _countHeath.text = ParametrView.ConvertToViewValue(healthToView);
        _healthBar.size = healthToView / _maxHealth;
    }

    public void SetMaxHealth(float maxHealth)
    {
        _maxHealth = maxHealth;
    }
}
