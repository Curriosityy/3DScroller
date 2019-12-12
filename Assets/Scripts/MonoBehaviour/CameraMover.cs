using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    float _cameraClamp1 = 22f, _cameraClamp2 = 30f;
    float _cameraSpeed = 15;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > _cameraClamp1)
                transform.Translate(new Vector3(-1 * Time.deltaTime * _cameraSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < _cameraClamp2)
                transform.Translate(new Vector3(Time.deltaTime * _cameraSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(new Vector3(transform.position.x, 0, 0),Vector3.right, _cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(new Vector3(transform.position.x, 0, 0), Vector3.right, -1*_cameraSpeed * Time.deltaTime);
        }
    }
}