using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Text _waveText;
    [SerializeField] private SliderBar _healthBar;
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private ObjectPooler _objectPool;

    [Header("Options")]
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private float _minSpawnInterval = 0.25f;
    [SerializeField] private float _intervalDecreaseRate = 0.25f;
    [SerializeField] private float _intervalDecreaseTime = 10f;
    private float _spawnTimer;
    private float _currentInterval;
    private int _waveValue = 1;

    private void Start()
    {
        UpdateWaveText();

        _healthBar.SetMaxValue(_intervalDecreaseTime);

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
        _healthBar.SetHealth(_intervalDecreaseTime);

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

            _intervalDecreaseTime = 15f;
        }
    }

    void SpawnEnemy()
    {
        GameObject obj = _objectPool.GetObject();
        if (obj != null)
        {
            EnemyHealth enemyScript = obj.GetComponent<EnemyHealth>();
            if (enemyScript != null)
            {
                enemyScript.SetMaxHealthValue();
            }

            float randomX = Random.Range(-2f, 2f);
            float randomY = Random.Range(-2f, 2f);
            Vector3 randomOffset = new Vector3(randomX, randomY, 0f);
            Vector3 spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position + randomOffset;

            obj.transform.position = spawnPosition;
            obj.transform.rotation = Quaternion.identity;

            obj.SetActive(true);
        }
    }

    private void UpdateWaveText()
    {
        _waveText.text = " Wave " + _waveValue;
    }
}