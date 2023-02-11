using System;
using UnityEngine;
using UnityEngine.UI;

public class ImprovementClickValue : MonoBehaviour
{
    [SerializeField] private Parametr _playerMoney;
    [SerializeField] private ViewImprovementClickValue _view;
    [SerializeField] private ClickMechanick _clickMechanic;
    [SerializeField] private AudioPlayer _sound;
    [SerializeField] private Button _buyButton;
    [SerializeField] private float _procentToAddCost;
    [SerializeField] private float _procentToBustTapMoney;
    [SerializeField] private string _title;

    private ImprovementHaracteristics _haracteristics;

    public string Title => _title;
    public float CurrentLevel => _haracteristics.CurrentLevel;
    public float CostUpdate => _haracteristics.CostUpdate;

    public void UpdateParamentsView()
    {
        Load();
        _view.UpdateData(this);

        if(_playerMoney.Value <= _haracteristics.CostUpdate)
        {
            _buyButton.interactable = false;
        }
        else
        {
            _buyButton.interactable = true;
        }
    }

    private void Awake()
    {
    }

    private void Start()
    {
        Load();
        UpdateParamentsView();
    }

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(UpdateParametr);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(UpdateParametr);
    }

    private void UpdateParametr()
    {
        Load();
        if(_playerMoney.Value >= _haracteristics.CostUpdate)
        {
            _sound.PlaySound(0);

            _playerMoney.AddValueToParametr(-_haracteristics.CostUpdate);

            _haracteristics.CurrentLevel++;
            _haracteristics.CostUpdate += (_haracteristics.CostUpdate * UnityEngine.Random.Range(10, _procentToAddCost)) / 100;

            _clickMechanic.Upgrade(_procentToBustTapMoney);
            _clickMechanic.Save();

            Save();
            UpdateParamentsView();
        }
    }

    private void Load()
    {
        if(PlayerPrefs.HasKey("BuyBustMoneyTap") == true)
        {
            _haracteristics = JsonUtility.FromJson<ImprovementHaracteristics>(PlayerPrefs.GetString("BuyBustMoneyTap"));
        }
        else
        {
            _haracteristics = new ImprovementHaracteristics();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetString("BuyBustMoneyTap", JsonUtility.ToJson(_haracteristics));
    }
}
