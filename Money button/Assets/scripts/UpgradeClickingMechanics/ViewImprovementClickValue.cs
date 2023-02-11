using UnityEngine;
using TMPro;

public class ViewImprovementClickValue : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _addMoneyCount;
    [SerializeField] private TMP_Text _currentLevel;
    [SerializeField] private TMP_Text _costUpdate;
    [SerializeField] private ClickMechanick _clikMechanik;

    public void UpdateData(ImprovementClickValue bust)
    {
        _title.text = bust.Title;
        _addMoneyCount.text = ParametrView.ConvertToViewValue(_clikMechanik.BustMoney);
        _currentLevel.text = ParametrView.ConvertToViewValue(bust.CurrentLevel);
        _costUpdate.text = ParametrView.ConvertToViewValue(bust.CostUpdate);
    }
}
