using System.Collections;
using UnityEngine;
using TMPro;

public class PassiveSalary : MonoBehaviour
{
    [SerializeField] private Parametr _money;
    [SerializeField] private TMP_Text _textAddMoney;

    private float _passiveSalary = 0;

    private const string SaveKeyParametrs = "PassiveIncoming";

    private void Start()
    {
        StartCoroutine(AddMoneyTime());
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey(SaveKeyParametrs) == true)
        {
            _passiveSalary = PlayerPrefs.GetFloat(SaveKeyParametrs);
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(SaveKeyParametrs, _passiveSalary);
    }

    public void UpgradePassiveSalary(float bustValue)
    {
        Load();

        float valueToAdd = ((_passiveSalary * bustValue) / 100) + 1;

        _passiveSalary += valueToAdd;
        _textAddMoney.text = $"+{ParametrView.ConvertToViewValue(_passiveSalary)}/s.";
        Save();
    }

    private IEnumerator AddMoneyTime()
    {
        Load();
        while (true)
        {
            _money.AddValueToParametr(_passiveSalary);
            _textAddMoney.text = $"+{ParametrView.ConvertToViewValue(_passiveSalary)}/s.";

            yield return new WaitForSeconds(1);
        }
    }
}
