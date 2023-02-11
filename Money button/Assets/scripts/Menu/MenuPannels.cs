using UnityEngine;

public class MenuPannels : MonoBehaviour
{
    [SerializeField] private GameObject[] _menuPannels;

    public void OffAllPannels()
    {
        for (int i = 0; i < _menuPannels.Length; i++)
        {
            _menuPannels[i].SetActive(false);
        }
    }

    public void ActivePannel(int indexPannelToOpen)
    {
        OffAllPannels();
        _menuPannels[indexPannelToOpen].SetActive(true);

    }
}
