using UnityEngine;

public class InfromationBonusViews : MonoBehaviour
{
    [SerializeField] private Bonus[] _viewToUpdateHaracteristics;

    private void OnEnable()
    {
        UpdateViews();
    }

    public void UpdateViews()
    {
        foreach(var view in _viewToUpdateHaracteristics)
        {
            view.UpdateViewData();
        }
    }
}
