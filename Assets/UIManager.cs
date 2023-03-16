using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Text _moneyText, _damageText, _speedAttackText, _rangeOfAttackText;
    [SerializeField] private GameObject _deathMenu, _victoryMenu;
    private PlayerBaseInfo _baseInfo;
    private int _money;

    private void Start()
    {
        _baseInfo = FindObjectOfType<PlayerBaseInfo>();

        _moneyText.text = " $ " + _money;
        _damageText.text = "" + _baseInfo.Damage;
        _speedAttackText.text = "" + _baseInfo.AttackSpeed;
        _rangeOfAttackText.text = "" + _baseInfo.RangeOfAttack;


        _baseInfo.AttackSpeedChanged += OnSpeedAttackChanged;
        _baseInfo.RangeOfAttackChanged += OnRangeOfAttackChanged;
        _baseInfo.DamageChanged += OnDamageChanged;
    }

    public void SetGold(int value)
    {
        _money += value;
        _moneyText.text = " $ " + _money;
    }

    public void TakeGold(int value)
    {
        _money -= value;
        _moneyText.text = " $ " + _money;
    }

    public int GoldCheck()
    {
        return _money;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDamageChanged(int newDamage)
    {
        _damageText.text = "" + newDamage;
    }

    private void OnSpeedAttackChanged(float newSpeed)
    {
        _speedAttackText.text = "" + newSpeed;
    }

    private void OnRangeOfAttackChanged(float newRange)
    {
        _rangeOfAttackText.text = "" + newRange;
    }
}
