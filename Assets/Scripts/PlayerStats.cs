using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlayerStats : MonoBehaviour {
    private int HP;

    // Start is called before the first frame update
    void Start()
    {
        HP = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetHP() {
        return HP;
    }

    public void DecrementHP() {
        HP--;
    }
}
