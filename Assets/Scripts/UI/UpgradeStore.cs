using UnityEngine;
using UnityEngine.UI;

public class UpgradeStore : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _attackSpeedButton;
    [SerializeField] private Button _rangeOfAttackButton;
    private UIManager _uiScript;
    private PlayerBaseInfo _baseInfoScript;

    [Header("Options")]
    [SerializeField] private int _damageAttackPrice, _speedAttackPrice, _rangeOfAttackPrice;
    [SerializeField] private Text _damageAttackText, _speedAttackText, _rangeOfAttackText;
    [SerializeField] private int _damageAttackValue;
    [SerializeField] private float _speedAttackValue;
    [SerializeField] private float _rangeOfAttackValue;
    private int _money;

    private void Start()
    {
        _baseInfoScript = GameObjectManager.instance.allObjects[0].GetComponent<PlayerBaseInfo>();
        _uiScript = GameObjectManager.instance.allObjects[1].GetComponent<UIManager>();
        _money = _uiScript.CheckMoney();
        UpdateTextPrice();
    }

    public void BuyAttackDamage()
    {
        UpdateMoneyValue();

        if (_money >= _damageAttackPrice)
        {
            _money -= _damageAttackPrice;
            _uiScript.TakeMoney(_damageAttackPrice);
            _baseInfoScript.Damage += _damageAttackValue;

            _damageAttackPrice += 3;
            UpdateTextPrice();
        }
    }

    public void BuyAttackSpeed()
    {
        UpdateMoneyValue();

        if (_money >= _speedAttackPrice)
        {
            _money -= _speedAttackPrice;
            _uiScript.TakeMoney(_speedAttackPrice);
            _baseInfoScript.AttackSpeed += _speedAttackValue;

            _speedAttackPrice += 3;
            UpdateTextPrice();
        }
    }

    public void BuyRangeOfAttack()
    {
        UpdateMoneyValue();

        if (_money >= _rangeOfAttackPrice)
        {
            _money -= _rangeOfAttackPrice;
            _uiScript.TakeMoney(_rangeOfAttackPrice);
            _baseInfoScript.RangeOfAttack += _rangeOfAttackValue;

            _rangeOfAttackPrice += 3;
            UpdateTextPrice();
        }
    }

    private void UpdateMoneyValue()
    {
        _money = _uiScript.CheckMoney();
    }

    private void UpdateTextPrice()
    {
        _damageAttackText.text = _damageAttackPrice + " $";
        _speedAttackText.text = _speedAttackPrice + " $";
        _rangeOfAttackText.text = _rangeOfAttackPrice + " $";
    }
}
