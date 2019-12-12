using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    float _speed = 0.1f;
    float _xStart = 0;
    float _xEnd = 50;
    float _gap = 10;
    float _current;
    float _time;
    bool _initialized = false;
    // Update is called once per frame
    void Update()
    {
        if (_initialized)
        {
            _time += Time.deltaTime;
            _current = Mathf.Lerp(_xStart, _xEnd, _time * 0.1f);
            transform.position = new Vector3(_current,
                (_xEnd / _gap - _current / _gap) * Mathf.Cos(_current),
                (_xEnd / _gap - _current / _gap) * Mathf.Sin(_current));
        }
        if(_current==_xEnd)
        {
            gameObject.SetActive(false);
        }
    }
    public void Initialize(float speed)
    {
        _speed = speed;
        _xStart = 0;
        _xEnd = 50;
        _current = 0;
        _time=0;
        _initialized = true;
    }
    private void OnDisable()
    {
        _initialized = false;
    }
}
