using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class EnemyJetBehaviour : MonoBehaviour {
    private int nHealth;
    [SerializeField] private int nMaxHealth;
    private float speed;
    [SerializeField] private float maxLifetime;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        nMaxHealth = 1;
        nHealth = nMaxHealth;
        speed = 1.5f;
        maxLifetime = 3.0f;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(nHealth > 0 && timer < maxLifetime) {
            transform.position += Vector3.back * Time.deltaTime * speed;
            timer += Time.deltaTime;
        }
        else if(nHealth <= 0) {
            timer = 0.0f;
            Debug.LogWarning("I'm hit!");
            Destroy(this.gameObject);
        }
        else if(timer >= maxLifetime) {
            timer = 0.0f;
            //Debug.LogWarning("Self-destructing jet");
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Bullet") {
            nHealth--;
        }
        else if(collision.gameObject.tag == "Turret") {
            //player minus health
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            nHealth--;
        }
        else if (other.gameObject.tag == "Turret")
        {
            //player minus health
            Destroy(this.gameObject);
        }
    }
}
