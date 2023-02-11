using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickMechanick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Parametr _playerMoney;
    [SerializeField] private Sprite _pressedButtonAnimation;
    [SerializeField] private Image _iconButton;
    [SerializeField] private Image _shadowIconButton;
    [SerializeField] private ViewTextClickMechanickAniamtion _animationAddMoneyText;
    [SerializeField] private RectTransform _parentToSpawn;
    [SerializeField] private AudioPlayer _sound;
    [SerializeField] private Worker _worker;
    [SerializeField] private WorkerAnimation _workerAnimation;
    [SerializeField] private bool _autoClick;

    private int _textIndex;
    private ViewTextClickMechanickAniamtion[] _poolTextAnimation = new ViewTextClickMechanickAniamtion[15];
    private Sprite _startSpriteButton;

    private ClickMechanickHaracteristics _haracteristics;

    public float BustMoney => _haracteristics.MoneyToAdd;
    
    private void Start()
    {
        Load();
        _startSpriteButton = _iconButton.sprite;

        for (int i = 0; i < _poolTextAnimation.Length; i++)
        {
            _poolTextAnimation[i] = Instantiate(_animationAddMoneyText, _parentToSpawn.transform);
        }

        StartCoroutine(autoFarm());
    }

    public void Upgrade(float procentToAdd)
    {
        _haracteristics.MoneyToAdd += (_haracteristics.MoneyToAdd * Random.Range(3, procentToAdd)) / 100;
    }

    public void AddMoneyAndTakeRockDamage()
    {
        _playerMoney.AddValueToParametr(_haracteristics.MoneyToAdd);

        _sound.PlaySound(0);
        _shadowIconButton.enabled = false;
        _iconButton.sprite = _pressedButtonAnimation;

        _poolTextAnimation[_textIndex].StartMotion(_haracteristics.MoneyToAdd);
        _textIndex++;

        _worker.TakeDamage();

        if (_textIndex >= _poolTextAnimation.Length)
        {
            _textIndex = 0;
        }

        _workerAnimation.SetSecondFrame();

        _haracteristics.CountClicks++;
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetString("tap", JsonUtility.ToJson(_haracteristics));
    }

    private void Load()
    {
        if(PlayerPrefs.HasKey("tap") == true)
        {
            _haracteristics = JsonUtility.FromJson<ClickMechanickHaracteristics>(PlayerPrefs.GetString("tap"));
        }
        else
        {
            _haracteristics = new ClickMechanickHaracteristics();
        }
    }

    private IEnumerator autoFarm()
    {
        while (_autoClick)
        {
            AddMoneyAndTakeRockDamage();
            yield return new WaitForSeconds(0.01f);
        }

        yield return null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AddMoneyAndTakeRockDamage();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _workerAnimation.SetDefaultFrame();
        _sound.PlaySound(1);
        _iconButton.sprite = _startSpriteButton;
        _shadowIconButton.enabled = true;
    }
}
