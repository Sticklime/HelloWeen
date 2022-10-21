using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera _mainCamer;

    private void Start() => 
        _mainCamer = Camera.main;

    private void Update()
    {
        Quaternion rotation = _mainCamer.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.back,rotation * Vector3.up);
    }
}
