using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject _enemyJetPrefab;
    private bool _bEnemyActive;
    [SerializeField] private float maxLifetime;
    private float timer;
    [SerializeField] private float spawnInterval;
    private float spawnTimer;
    //[SerializeField] PlayerStats _playerStats;

    // Start is called before the first frame update
    void Start()
    {
        _bEnemyActive = false;
        maxLifetime = 30.0f;
        timer = 0.0f;
        spawnInterval = 3.0f;
        spawnTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < maxLifetime) {//&& _playerStats.GetHP() > 0
            if(spawnTimer >= spawnInterval) {
                _bEnemyActive = false;
                spawnTimer = 0.0f;
            }
            if(_bEnemyActive == false) {
                GameObject _jet = GameObject.Instantiate(_enemyJetPrefab);
                _jet.transform.parent = this.gameObject.transform;
                _jet.transform.localPosition = new Vector3(0, 0, 0);
                _bEnemyActive = true;
            }
            timer += Time.deltaTime;
            spawnTimer += Time.deltaTime;
        }
        else {
            //
        }
    }
}
