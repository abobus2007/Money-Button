using UnityEngine;
using TMPro;

public class Ucheevment : MonoBehaviour
{
    [SerializeField] private Parametr _moneyPlayer;
    [SerializeField] protected TMP_Text _title;
    [SerializeField] protected string _congratulationText;
    [SerializeField] private float _howMoreMoneyMustPlayerHave; 

    private const string SaveKey = "Ucheevment";

    public virtual void CheckIsSuccessConditions()
    {
        if (PlayerPrefs.HasKey(SaveKey + _title.text) == true)
        {
            _title.text = _congratulationText;
        }

        _title.text = $"Get tap bust money: {ParametrView.ConvertToViewValue(_howMoreMoneyMustPlayerHave)}";

        if(_howMoreMoneyMustPlayerHave <= _moneyPlayer.Value)
        {
            _title.text = _congratulationText;
        }
    }
}
