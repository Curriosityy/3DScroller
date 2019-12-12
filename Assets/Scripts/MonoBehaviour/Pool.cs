using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : Singleton<Pool>
{
    CubePooler[] _obj;
    Queue<GameObject> _pool;
    int _initialPoolSize=20;
    Transform _objectHolder;
    bool _initialized = false;
    private void Awake() {
        _pool = new Queue<GameObject>();
        _objectHolder = new GameObject("[PoolHolder] Cube").transform;
    }
    public void Initialize(CubePooler[] objectPrefabs)
    {
        _obj = objectPrefabs;
        GameObject instance;
        for (int i = 0; i < _initialPoolSize; i++)
        {
            instance = Instantiate(_obj[Random.Range(0,_obj.Length)].gameObject, _objectHolder);
            instance.SetActive(false);
            _pool.Enqueue(instance);
        }
        _initialized = true;
    }

    public GameObject GetFromPool()
    {
        if (!_initialized)
        {
            Debug.LogError("pool is not initialized");
            return null;
        }
        if (_pool.Count==0)
        {
            _pool.Enqueue(Instantiate(_obj[Random.Range(0, _obj.Length)].gameObject, _objectHolder));
        }
        return _pool.Dequeue();
    }

    public void AddToPool(GameObject objectToPooling)
    {
        _pool.Enqueue(objectToPooling);
    }
}
