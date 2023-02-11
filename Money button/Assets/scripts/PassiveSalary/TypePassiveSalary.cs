using UnityEngine;
using UnityEngine.UI;

public class TypePassiveSalary : MonoBehaviour
{
    [SerializeField] private ViewTypePassiveSalary _view;
    [SerializeField] private Parametr _playerMoney;
    [SerializeField] private Button _buyButton;
    [SerializeField] private PassiveSalary _passiveSalary;
    [SerializeField] private Image _backgroundTimerMining;
    [SerializeField] private Image _icon;
    [SerializeField] private AudioPlayer _sound;
    [SerializeField] private TypesPassiveSalary _allSalarys;

    [SerializeField] private string _title;
    [SerializeField] private int _maxLevel;
    [SerializeField] private float _moneyTimerProcentBust;
    [SerializeField] private float _costProcentBust;
    [SerializeField] private Sprite[] _icons;
    [SerializeField] private HaracteristicTypePassiveSalary Harateristics;

    public string Title => _title;
    public float MoneyTimerProcentBust => _moneyTimerProcentBust;
    public float CurrentLevel => Harateristics.CurrentLevel;
    public float CostUpdate => Harateristics.CostUpdate;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(BuyPassiveSalary);
        UpdateView();
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(BuyPassiveSalary);
    }

    private void BuyPassiveSalary()
    {
        Load();

        if (_playerMoney.Value >= Harateristics.CostUpdate)
        {
            _sound.PlaySound(0);
            _playerMoney.AddValueToParametr(-Harateristics.CostUpdate);

            Harateristics.CurrentLevel++;
            Harateristics.CostUpdate += (Harateristics.CostUpdate * UnityEngine.Random.Range(10, _costProcentBust)) / 100;

            Save();

            _passiveSalary.UpgradePassiveSalary(_moneyTimerProcentBust);
            _allSalarys.LoadUpdatesPassiveSalarys();

            LoadIcon();
            UpdateView();
            CheckBuyButtonState();
        }
    }

    private void LoadIcon()
    {
        int levelUpdateIcon = _maxLevel / _icons.Length;
        if(Harateristics.CurrentLevel == 0)
        {
            _backgroundTimerMining.sprite = _icons[0];
            _icon.sprite = _icons[1];
            Harateristics.IconId = 1;
            Save();
            return;
        }

        if (Harateristics.LevelToGiveNextIcon <= Harateristics.CurrentLevel)
        {
            Harateristics.IconId++;

            if (Harateristics.IconId >= _icons.Length)
            {
                Harateristics.IconId = _icons.Length - 1;
            }

            Harateristics.LevelToGiveNextIcon = Harateristics.LevelToGiveNextIcon + levelUpdateIcon;
        }

        _backgroundTimerMining.sprite = _icons[Harateristics.IconId];
        _icon.sprite = _icons[Harateristics.IconId];
    }

    public void UpdateView()
    {
        Load();
        _view.UpdateDataView(this);
        CheckBuyButtonState();
        LoadIcon();
    }

    public void Init()
    {
        Load();
        UpdateView();
        LoadIcon();
    }

    private void CheckBuyButtonState()
    {
        if(Harateristics.CurrentLevel < _maxLevel)
        {
            _buyButton.interactable = true;
        }
        else
        {
            _buyButton.interactable = false;
            _view.SetDataCostView("Max level");
            return;
        }

        if (_playerMoney.Value >= Harateristics.CostUpdate)
        {
            _buyButton.interactable = true;
        }
        else
        {
            _buyButton.interactable = false;
        }
    }

    private void Load()
    {
        if(PlayerPrefs.HasKey("BuyBustMoney" + _title) == true)
        {
            Harateristics = JsonUtility.FromJson<HaracteristicTypePassiveSalary>(PlayerPrefs.GetString("BuyBustMoney" + _title));
        }
    }

    private void Save()
    {
        PlayerPrefs.SetString("BuyBustMoney" + _title, JsonUtility.ToJson(Harateristics));
    }
}
