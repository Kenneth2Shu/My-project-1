using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ObjectChanger : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private GameObject _pyramidPrefab;
    [SerializeField] private float yOffset = 0.5f;

    public void objectChange1() {
        GameObject _cube = GameObject.Instantiate(_cubePrefab);
        //_cube.transform.parent = image.transform;
        //_cube.transform.localPosition = new Vector3(0, yOffset, 0);
    }

    public void objectChange2() {
        //
    }
}
