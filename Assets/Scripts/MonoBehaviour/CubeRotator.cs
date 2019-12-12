using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{

    bool _initialized = false;
    Vector3 _rotationSpeed;
    Vector3 _rotationLook;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(_initialized)
        {
            RotateCube();
        }
    }
    public void Initialize(Vector3 rotation,Vector3 speed)
    {
        _rotationSpeed = speed;
        _rotationLook = rotation;
        _initialized = true;
    }
    private void RotateCube()
    {
        transform.Rotate(new Vector3(_rotationLook.x * _rotationSpeed.x ,
                                     _rotationLook.y * _rotationSpeed.y  ,
                                     _rotationLook.z * _rotationSpeed.z  ));
    }
    private void OnDisable()
    {
        _initialized = false;
    }
}
