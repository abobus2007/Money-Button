using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    [SerializeField] private Parametr _cristalPlayer;
    [SerializeField] private Parametr _moneyPlayer;
    [SerializeField] public ViewBonus _view;
    [SerializeField] private Button _buyButton;
    [SerializeField] private ClickMechanick _clickableMechanick;
    [SerializeField] private AudioPlayer _sound;

    [SerializeField] private string _title;
    [SerializeField] private int _cristalCost;
    [SerializeField] private int _moneyCost;
    [SerializeField] private float _procentFromClickBust;

    public string Title => _title;
    public int CristalCost => _cristalCost;
    public int MoneyCost => _moneyCost;

    private void Start()
    {
        UpdateViewData();
        _buyButton.onClick.AddListener(BuyUpdate);
    }

    public virtual void BuyUpdate()
    {
        _sound.PlaySound(0);

        _clickableMechanick.Upgrade(GetCountBustValue());

        _moneyPlayer.AddValueToParametr(-_moneyCost);
        _cristalPlayer.AddValueToParametr(-_cristalCost);

        PlayerPrefs.SetInt("BuyBust" + _title, 1);
        _view.BuyedText();
        ChangeStateBuyButton();
    }

    private float GetCountBustValue()
    {
        return ((_clickableMechanick.BustMoney * _procentFromClickBust) / 100) + 1;
    }

    public void UpdateViewData()
    {
        _view.BuyedText($"+{_procentFromClickBust}%");
        ChangeStateBuyButton();
        _view.UpdateData(this);
    }

    private void ChangeStateBuyButton()
    {
        if(PlayerPrefs.HasKey("BuyBust" + _title) == true)
        {
            _buyButton.interactable = false;
            _view.BuyedText();
            return;
        }

        if (_cristalPlayer.Value >= _cristalCost && _moneyPlayer.Value >= _moneyCost)
        {
            _buyButton.interactable = true;
        }
        else
        {
            _buyButton.interactable = false;
            _view.BuyedText("Money or _playerCristals");
        }
    }
}
