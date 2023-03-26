using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Text _waveText;
    [SerializeField] private SliderBar _sliderBar;
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private ObjectPooler _objectPool;
    private UIManager _uiScripts;

    [Header("Options")]
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private float _minSpawnInterval = 0.25f;
    [SerializeField] private float _intervalDecreaseRate = 0.25f;
    [SerializeField] private float _intervalDecreaseTime = 15f;
    private float _spawnTimer;
    private float _currentInterval;
    private int _waveValue = 1;

    private void Start()
    {
        UpdateWaveText();

        _uiScripts = GameObjectManager.instance.allObjects[1].GetComponent<UIManager>();

        _sliderBar.SetMaxValue(_intervalDecreaseTime);

        _currentInterval = _spawnInterval;

    }

    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0)
        {
            _spawnTimer = _currentInterval;
            SpawnEnemy();
        }

        _intervalDecreaseTime -= Time.deltaTime;
        _sliderBar.SetHealth(_intervalDecreaseTime);

        if (_intervalDecreaseTime <= 0)
        {
            _waveValue++;

            _spawnInterval -= _intervalDecreaseRate;
            _currentInterval = _spawnInterval;

            if (_spawnInterval < _minSpawnInterval)
            {
                _spawnInterval = _minSpawnInterval;
                _currentInterval = _spawnInterval;
            }

            UpdateWaveText();

            EnemyStats.Health += 0.25f;
            EnemyStats.Damage += 0.25f;
            if (EnemyStats.Speed < 5f)
            {
                EnemyStats.Speed += 0.05f;
            }

            _uiScripts.UpdateEnemyStatus();

            _intervalDecreaseTime = 20f;
        }
    }

    void SpawnEnemy()
    {
        int numberOfEnemies = Random.Range(2, 5); // случайное количество врагов от 2 до 4
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject obj = _objectPool.GetObject();
            if (obj != null)
            {
                EnemyHealth enemyHealthScript = obj.GetComponent<EnemyHealth>();
                EnemyMovement enemyMovementScript = obj.GetComponent<EnemyMovement>();
                EnemyMeleeAttack enemyDamageScript = obj.GetComponent<EnemyMeleeAttack>();
                if (enemyHealthScript != null)
                {
                    enemyHealthScript.SetMaxHealthValue();
                }
                if (enemyMovementScript != null)
                {
                    enemyMovementScript.SetSpeedValue();
                }
                if (enemyDamageScript != null)
                {
                    enemyDamageScript.SetDamageValue();
                }

                float randomX = Random.Range(-2f, 2f);
                float randomY = Random.Range(-2f, 2f);
                Vector3 randomOffset = new Vector3(randomX, randomY, 0f);
                Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position + randomOffset;

                obj.transform.position = spawnPosition;

                obj.SetActive(true);
            }
        }
    }

    private void UpdateWaveText()
    {
        _waveText.text = " Wave " + _waveValue;
    }
}