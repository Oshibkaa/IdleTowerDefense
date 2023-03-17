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
    [SerializeField] private int _damageAttackValue;
    [SerializeField] private float _speedAttackValue;
    [SerializeField] private float _rangeOfAttackValue;
    private int _money;
    private int _numberOfDamageUpgrades = 2;
    private int _numberOfspeedAttackUpgrades = 2;
    private int _numberOfrangeOfAttackUpgrades = 2;

    private void Start()
    {
        _baseInfoScript = GameObjectManager.instance.allObjects[0].GetComponent<PlayerBaseInfo>();
        _uiScript = GameObjectManager.instance.allObjects[1].GetComponent<UIManager>();
        _money = _uiScript.CheckMoney();
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
                _uiScript.TakeMoney(_damageAttackPrice);
                _baseInfoScript.Damage += _damageAttackValue;

                UpdateUIButton();
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
                _uiScript.TakeMoney(_speedAttackPrice);
                _baseInfoScript.AttackSpeed += _speedAttackValue;

                UpdateUIButton();
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
                _uiScript.TakeMoney(_rangeOfAttackPrice);
                _baseInfoScript.RangeOfAttack += _rangeOfAttackValue;

                UpdateUIButton();
            }
        }
    }

    private void UpdateUIButton()
    {
        if (_numberOfDamageUpgrades <=  0)
        {
            _damageButton.interactable = false;
            _damageButton.GetComponent<Image>().color = new Color(0, 0, 0);
        }
        if (_numberOfspeedAttackUpgrades <= 0)
        {
            _attackSpeedButton.interactable = false;
            _attackSpeedButton.GetComponent<Image>().color = new Color(0, 0, 0);
        }
        if (_numberOfrangeOfAttackUpgrades <= 0)
        {
            _rangeOfAttackButton.interactable = false;
            _rangeOfAttackButton.GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }

    private void UpdateGoldValue()
    {
        _money = _uiScript.CheckMoney();
    }
}
