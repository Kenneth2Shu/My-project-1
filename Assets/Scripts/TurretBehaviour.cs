using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TurretBehaviour : MonoBehaviour {
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletInterval;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        bulletInterval = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void FiringTurret() {
        Debug.Log("Imma firin' mah laser!");
        //animator.SetTrigger("fire");
        animator.SetBool("fireState", true);
        animator.SetBool("idleState", false);
    }

    public void FireTurret() {
        if(timer >= bulletInterval) {
            GameObject _bullet = GameObject.Instantiate(bulletPrefab);
            _bullet.transform.parent = this.gameObject.transform;
            _bullet.transform.localPosition = new Vector3(0, 1, 0);
            timer = 0.0f;
        }
    }

    public void IdleState() {
        animator.SetBool("fireState", false);
        animator.SetBool("idleState", true);
    }
}
