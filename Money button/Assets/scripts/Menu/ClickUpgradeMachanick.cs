using UnityEngine;

public class ClickUpgradeMachanick : MonoBehaviour
{
    [SerializeField] private ImprovementClickValue _improvementClick;

    private void OnEnable()
    {
        _improvementClick.UpdateParamentsView();
    }
}
