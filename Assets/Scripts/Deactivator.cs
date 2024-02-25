using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class Deactivator : MonoBehaviour{
    private bool bHide;
    
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "Settings") {
            this.bHide = true;
        }
        else {
            this.bHide = false;
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableSettingsPanel() {
        if(this.bHide) {
            gameObject.SetActive(true);
            Debug.Log("Showing Settings.");
            this.bHide = false;
        }
        else {
            gameObject.SetActive(false);
            Debug.Log("Hiding Settings.");
            this.bHide = true;
        }
    }
}
