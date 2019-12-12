using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
    [SerializeField] CubePooler[] _cubePrefab;
    float _spwningTime = 1f;
    float _cubeSpeed = 1f;
    float _currentTime = 0;
    [SerializeField] List<Slider> _slidersSpeed;
    [SerializeField] List<Slider> _slidersRotation;
    [SerializeField] Toggle _rotationTurner;
    // Start is called before the first frame update
    void Awake()
    {
        Pool.Instance.Initialize(_cubePrefab);
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime>=_spwningTime)
        {
            SpawnCube();
            _currentTime = 0;
        }
    }
    private void SpawnCube()
    {
        GameObject ob = Pool.Instance.GetFromPool();
        
        ob.GetComponent<CubeMover>().Initialize(_cubeSpeed);
        ob.GetComponent<CubeRotator>().Initialize(getRotationVector(), getRotationSpeedVector());
        ob.SetActive(true); 

    }
    private Vector3 getRotationVector()
    {
        if(_rotationTurner.isOn)
        {
            return new Vector3(_slidersRotation[0].value, _slidersRotation[1].value, _slidersRotation[2].value);
        }
        return Vector3.zero;
    }
    private Vector3 getRotationSpeedVector()
    {
        if (_rotationTurner.isOn)
        {
            return new Vector3(_slidersSpeed[0].value, _slidersSpeed[1].value, _slidersSpeed[2].value);
        }
        return Vector3.zero;
    }

}
