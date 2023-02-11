using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParametrView : MonoBehaviour
{
    [SerializeField] private TMP_Text _actualValue;

    public void UpdateTextValue(float valueToSet)
    {
        _actualValue.text = ConvertToViewValue(valueToSet);
    }

    public static string ConvertToViewValue(float valueToConvert)
    {
        string[] nameValue =
        {
            "",
            "K",
            "M",
            "B",
            "T",
        };

        if (valueToConvert == 0) return "0";

        int i = 0;
        while (i + 1 < nameValue.Length && valueToConvert >= 1000f)
        {
            valueToConvert /= 1000f;
            i++;
        }

        return valueToConvert.ToString(format: "#.###") + " " + nameValue[i];
    }
}
