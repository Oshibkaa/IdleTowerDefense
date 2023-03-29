using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Text _moneyText, _damageText, _speedAttackText, _rangeOfAttackText, _healthText;
    [SerializeField] private Text _enemyDamageText, _enemySpeedText, _enemyHealthText;
    [SerializeField] private GameObject _gameRestartWindow;
    private PlayerBaseInfo _baseInfoScript;
    private PlayerBaseHealth _baseHealthScript;
    private int _money;

    private void Start()
    {
        _baseInfoScript = GameObjectManager.instance.allObjects[0].GetComponent<PlayerBaseInfo>();
        _baseHealthScript = GameObjectManager.instance.allObjects[0].GetComponent<PlayerBaseHealth>();

        UpdatePlayerStatus();
        UpdateEnemyStatus();

        _money = 9;
        _moneyText.text = " $ " + _money;
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

    public void PauseGame()
    {
        Time.timeScale = 0f;
        _gameRestartWindow.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        EnemyStats.ResetStats();
    }

    private void OnDamageChanged(int newDamage)
    {
        _damageText.text = "" + newDamage;
    }

    private void OnSpeedAttackChanged(float newSpeed)
    {
        _speedAttackText.text = FormatNumber(newSpeed);
    }

    private void OnRangeOfAttackChanged(float newRange)
    {
        _rangeOfAttackText.text = FormatNumber(newRange);
    }

    public void UpdatePlayerStatus()
    {
        _damageText.text = "" + _baseInfoScript.Damage;
        _speedAttackText.text = FormatNumber(_baseInfoScript.AttackSpeed);
        _rangeOfAttackText.text = FormatNumber(_baseInfoScript.RangeOfAttack);
    }

    public void UpdateEnemyStatus()
    {
        _enemySpeedText.text = FormatNumber(EnemyStats.Speed);
        _enemyDamageText.text = FormatNumber(EnemyStats.Damage);
        _enemyHealthText.text = FormatNumber(EnemyStats.Health); 
    }

    public string FormatNumber(float number)
    {
        return number.ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
    }
}
