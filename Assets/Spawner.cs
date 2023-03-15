using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnEnemyPoint;

    [Header("Options")]
    [SerializeField] private int _enemiesValue = 2;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5f);

        for (int i = 0; i < _enemiesValue; i++)
        {
            Instantiate(_enemyPrefab, _spawnEnemyPoint[Random.Range(0, _spawnEnemyPoint.Length)].position, Quaternion.identity);
        }

        StartCoroutine(Spawn());
    }
}
