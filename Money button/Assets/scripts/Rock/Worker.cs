using UnityEngine;

public class Worker : MonoBehaviour
{
    [SerializeField] private RockHealthView _view;
    [SerializeField] private MaxTapDamageView _maxDamageView;
    [SerializeField] private SetRandomRockAnimation _randomRockView;
    [SerializeField] private Animator _damageAnimator;
    [SerializeField] private Parametr _playerCristals;
    [SerializeField] private int _damage = 1;
    [SerializeField] private int _countClicks = 1;

    private float _maxHealth = 10;
    private float _health = 10;
    private int _cristalsToAddPlayer = 1;

    private void Start()
    {
        GenerateNewRock();
    }

    public void TakeDamage()
    {
        _health -= _damage;
        _view.UpdateHealthParametr(_health);

        _damageAnimator.Play("DamageAnimation");
        CalculateDamage();

        if(_health <= 0)
        {
            GenerateNewRock();
            _playerCristals.AddValueToParametr(Random.Range(1, 2));
        }
    }

    private void CalculateDamage()
    {
        _countClicks++;

        if (_countClicks >= Random.Range(20, 35))
        {
            UpgradeDamageParametr();
        }
    }

    private void UpgradeDamageParametr()
    {
        if (_damage <= 100)
        {
            _countClicks = 0;
            _damage++;
            _maxDamageView.UpdateViewData(_damage);
        }
    }

    private void GenerateNewRock()
    {
        _randomRockView.SetRandom();
        _maxHealth += (_maxHealth * Random.Range(12, 35)) / 100;

        _view.SetMaxHealth(_maxHealth);

        _health = _maxHealth;
        _cristalsToAddPlayer = Random.Range(1, 2);

        _view.UpdateHealthParametr(_health);
    }
}
