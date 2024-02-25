using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class LevelHandler : MonoBehaviour {
    [SerializeField] private GameObject prefabLevel;

    private bool levelHasSpawned;

    // Start is called before the first frame update
    void Start()
    {
        levelHasSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnLevel() {
        
    }
}
