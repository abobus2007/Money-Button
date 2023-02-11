using UnityEngine;

public class CristalUcheevment : Ucheevment
{
    [SerializeField] private Parametr _playerCristals;
    [SerializeField] private int GettingCristals;

    public override void CheckIsSuccessConditions()
    {
        if (PlayerPrefs.HasKey("Ucheevment" + _title.text) == true)
        {
            _title.text = _congratulationText;
        }

        if (_playerCristals.Value >= GettingCristals)
        {
            _title.text = _congratulationText;
        }
    }
}
