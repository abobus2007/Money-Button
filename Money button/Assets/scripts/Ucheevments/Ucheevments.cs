using UnityEngine;

public class Ucheevments : MonoBehaviour
{
    [SerializeField] private Ucheevment[] _ucheevmentsToUpdate;

    private void OnEnable()
    {
        foreach (var ucheevments in _ucheevmentsToUpdate)
        {
            ucheevments.CheckIsSuccessConditions();
        }
    }
}
