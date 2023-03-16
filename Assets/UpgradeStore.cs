using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeStore : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _attackSpeedButton;
    [SerializeField] private Button _rangeOfAttackButton;
    private UIManager _ui;
    private PlayerBaseInfo _baseInfo;

    [Header("Options")]
    [SerializeField] private int _damageAttackPrice, _speedAttackPrice, _rangeOfAttackPrice;
    [SerializeField] private int _damageAttackValue;
    [SerializeField] private float _speedAttackValue;
    [SerializeField] private float _rangeOfAttackValue;
    private int _money;
    private int _numberOfDamageUpgrades = 2;
    private int _numberOfspeedAttackUpgrades = 2;
    private int _numberOfrangeOfAttackUpgrades = 2;

    private void Start()
    {
        _ui = FindObjectOfType<UIManager>();
        _baseInfo = FindObjectOfType<PlayerBaseInfo>();
        _money = _ui.GoldCheck();
    }

    public void BuyAttackDamage()
    {
        UpdateGoldValue();

        if (_numberOfDamageUpgrades > 0)
        {
            if (_money >= _damageAttackPrice)
            {
                _numberOfDamageUpgrades--;
                _money -= _damageAttackPrice;
                _ui.TakeGold(_damageAttackPrice);
                _baseInfo.Damage += _damageAttackValue;

                UpdateUIButton();
            }
            else
            {
            
            }
        }
    }

    public void BuyAttackSpeed()
    {
        UpdateGoldValue();

        if (_numberOfspeedAttackUpgrades > 0)
        {
            if (_money >= _speedAttackPrice)
            {
                _numberOfspeedAttackUpgrades--;
                _money -= _speedAttackPrice;
                _ui.TakeGold(_speedAttackPrice);
                _baseInfo.AttackSpeed += _speedAttackValue;

                UpdateUIButton();
            }
            else
            {
            
            }
        }
    }

    public void BuyRangeOfAttack()
    {
        UpdateGoldValue();

        if (_numberOfrangeOfAttackUpgrades > 0)
        {
            if (_money >= _rangeOfAttackPrice)
            {
                _numberOfrangeOfAttackUpgrades--;
                _money -= _rangeOfAttackPrice;
                _ui.TakeGold(_rangeOfAttackPrice);
                _baseInfo.RangeOfAttack += _rangeOfAttackValue;

                UpdateUIButton();
            }
            else
            {
            
            }
        }
    }

    private void UpdateUIButton()
    {
        if (_numberOfDamageUpgrades <=  0)
        {
            _damageButton.interactable = false;
        }
        if (_numberOfspeedAttackUpgrades <= 0)
        {
            _attackSpeedButton.interactable = false;
        }
        if (_numberOfrangeOfAttackUpgrades <= 0)
        {
            _rangeOfAttackButton.interactable = false;
        }
    }

    private void UpdateGoldValue()
    {
        _money = _ui.GoldCheck();
    }
}
