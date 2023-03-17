using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject[] _pooledObject;
    [SerializeField] private List<GameObject> _pooledObjects;

    [Header("Options")]
    [SerializeField] private int _poolSize = 10;


    void Start()
    {
        _pooledObjects = new List<GameObject>();
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(_pooledObject[Random.Range(0, _pooledObject.Length)], transform);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }
}