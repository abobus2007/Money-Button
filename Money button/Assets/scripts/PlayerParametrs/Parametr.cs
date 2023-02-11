using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Parametr : MonoBehaviour
{
    [SerializeField] private string _title;
    [SerializeField] private float _value;
    [SerializeField] private ParametrView _view;

    public float Value => _value;

    private void Start()
    {
        Load();
        _view.UpdateTextValue(_value);
    }

    public void AddValueToParametr(float valueToAdd)
    {
        Load();
        float valueToCheck = _value + valueToAdd;

        if (valueToCheck > 0)
        {
            _value = valueToCheck;
        }
        else
        {
            _value = 0;
        }

        _view.UpdateTextValue(_value);
        Save();
    }

    public bool CheckValue(long ValueToCheck)
    {
        if(_value >= ValueToCheck)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Parametr" + _title, Value);
    }

    private void Load()
    {
        if(PlayerPrefs.HasKey("Parametr" + _title) == true)
        {
            _value = PlayerPrefs.GetFloat("Parametr" + _title, Value);
        }
    }
}
