using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MaxTapDamageView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countDamage;
    [SerializeField] private Scrollbar _damageBar;

    public void UpdateViewData(float damageToView)
    {
        _countDamage.text = ParametrView.ConvertToViewValue(damageToView);
        _damageBar.size = damageToView / 100;
    }
}
