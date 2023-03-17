using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Text _moneyText, _damageText, _speedAttackText, _rangeOfAttackText, _healthText;
    private PlayerBaseInfo _baseInfoScript;
    private PlayerBaseHealth _baseHealthScript;
    private int _money;

    private void Start()
    {
        _baseInfoScript = GameObjectManager.instance.allObjects[0].GetComponent<PlayerBaseInfo>();
        _baseHealthScript = GameObjectManager.instance.allObjects[0].GetComponent<PlayerBaseHealth>();

        _moneyText.text = " $ " + _money;
        _damageText.text = "" + _baseInfoScript.Damage;
        _speedAttackText.text = "" + _baseInfoScript.AttackSpeed;
        _rangeOfAttackText.text = "" + _baseInfoScript.RangeOfAttack;
        _healthText.text = _baseHealthScript.CheckHealth + "/1";

        _baseInfoScript.AttackSpeedChanged += OnSpeedAttackChanged;
        _baseInfoScript.RangeOfAttackChanged += OnRangeOfAttackChanged;
        _baseInfoScript.DamageChanged += OnDamageChanged;
    }

    public void SetMoney(int value)
    {
        _money += value;
        _moneyText.text = " $ " + _money;
    }

    public void TakeMoney(int value)
    {
        _money -= value;
        _moneyText.text = " $ " + _money;
    }

    public int CheckMoney()
    {
        return _money;
    }

    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDamageChanged(int newDamage)
    {
        _damageText.text = newDamage.ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
    }

    private void OnSpeedAttackChanged(float newSpeed)
    {
        _speedAttackText.text = newSpeed.ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
    }

    private void OnRangeOfAttackChanged(float newRange)
    {
        _rangeOfAttackText.text = newRange.ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
    }
}
