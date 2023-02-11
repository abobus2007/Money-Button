using UnityEngine;
using TMPro;

public class ViewTypePassiveSalary : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _currentGetMoneyTime;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _costBust;

    public void UpdateDataView(TypePassiveSalary PassiveSalaryToView)
    {
        _title.text = PassiveSalaryToView.Title;
        _currentGetMoneyTime.text = ParametrView.ConvertToViewValue(PassiveSalaryToView.MoneyTimerProcentBust);
        _level.text = ParametrView.ConvertToViewValue(PassiveSalaryToView.CurrentLevel);
        _costBust.text = ParametrView.ConvertToViewValue(PassiveSalaryToView.CostUpdate);
    }

    public void SetDataCostView(string text)
    {
        _costBust.text = text;
    }
}
