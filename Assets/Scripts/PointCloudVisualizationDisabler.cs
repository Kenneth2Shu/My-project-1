using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class PointCloudVisualizationDisabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void EnableVisualization() {
        this.enabled = true;
    }

    public void DisableVisualization() {
        this.enabled = false;
    }

    public void LowTierGod() {
        //
    }
}
