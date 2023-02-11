using UnityEngine;
using TMPro;

public class ViewBonus : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _cristalCost;
    [SerializeField] private TMP_Text _moneyCost;
    [SerializeField] private TMP_Text _alreadyBuyed;

    public void UpdateData(Bonus bonus)
    {
        _title.text = bonus.Title;
        _cristalCost.text = "-" + ParametrView.ConvertToViewValue(bonus.CristalCost);
        _moneyCost.text = "-" + ParametrView.ConvertToViewValue(bonus.MoneyCost) + "$";
    }

    public void BuyedText(string text = "Buyed")
    {
        _alreadyBuyed.text = text;
    }
}
