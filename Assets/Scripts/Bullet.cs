using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Bullet : MonoBehaviour {
    [SerializeField] private float maxLifetime;
    //private Vector3 originalPosition;
    [SerializeField] private float speed;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        maxLifetime = 3.0f;
        speed = 1.0f;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < maxLifetime) {
            transform.position += Vector3.forward * Time.deltaTime * speed;
            timer += Time.deltaTime;
        }
        else{
            timer = 0.0f;
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy") {
            Destroy(collision.gameObject);
            Debug.Log("That's a hit!");
            Destroy(this.gameObject);
        }
    }
}
