using UnityEngine;

public class TypesPassiveSalary : MonoBehaviour
{
    [SerializeField] private TypePassiveSalary[] _passiveSalarys;

    private void Start()
    {
        foreach (var item in _passiveSalarys)
        {
            item.Init();
        }
    }

    public void LoadUpdatesPassiveSalarys()
    {
        foreach (var item in _passiveSalarys)
        {
            item.UpdateView();
        }
    }
}
