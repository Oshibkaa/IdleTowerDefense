using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Text _waveText;
    private int _waveValue = 1;
    [SerializeField] private TimeWaveSlider _healthBar;
    public ObjectPooler enemyPool;
    public Transform[] spawnPoints;
    public float spawnInterval = 2f;
    public float minSpawnInterval = 0.1f;
    public float intervalDecreaseRate = 0.1f;
    public float intervalDecreaseTime = 10f;

    private float spawnTimer;
    private float currentInterval;

    private void Start()
    {
        UpdateWaveText();

        _healthBar.SetMaxHealth(intervalDecreaseTime);

        currentInterval = spawnInterval;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = currentInterval;
            SpawnEnemy();
        }

        intervalDecreaseTime -= Time.deltaTime;
        _healthBar.SetHealth(intervalDecreaseTime);

        if (intervalDecreaseTime <= 0)
        {
            _waveValue++;
            spawnInterval -= intervalDecreaseRate;
            currentInterval = spawnInterval;
            if (spawnInterval < minSpawnInterval)
            {
                spawnInterval = minSpawnInterval;
                currentInterval = spawnInterval;
            }
            UpdateWaveText();
            intervalDecreaseTime = 10f;
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        GameObject enemy = enemyPool.GetPooledObject();
        if (enemy != null)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.UpdateHealth();
            }

            float randomX = Random.Range(-2f, 2f);
            float randomY = Random.Range(-2f, 2f);
            Vector3 randomOffset = new Vector3(randomX, randomY, 0f);
            Vector3 spawnPosition = spawnPoint.position + randomOffset;

            enemy.transform.position = spawnPosition;
            enemy.transform.rotation = spawnPoint.rotation;
            enemy.SetActive(true);
        }
    }

    private void UpdateWaveText()
    {
        _waveText.text = " Wave " + _waveValue;
    }
}