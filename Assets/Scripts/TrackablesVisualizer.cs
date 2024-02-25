using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TrackablesVisualizer : MonoBehaviour {
    private bool bPlaneVisual;

    // Start is called before the first frame update
    void Start()
    {
        this.bPlaneVisual = false;
        this.EnablePlaneVisualization();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnablePlaneVisualization() {
        if(this.bPlaneVisual) {
            gameObject.GetComponent<ARPlaneManager>().SetTrackablesActive(true);
            Debug.Log("Showing Plane.");
            this.bPlaneVisual = false;
        }
        else {
            gameObject.GetComponent<ARPlaneManager>().SetTrackablesActive(false);
            Debug.Log("Hiding Plane.");
            this.bPlaneVisual = true;
        }
    }
}
