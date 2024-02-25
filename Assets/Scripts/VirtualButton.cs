using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImage))]

public class VirtualButton : MonoBehaviour {
    private ARTrackedImage trackedImage;
    [SerializeField] private UnityEvent onTrackedImageLimited;

    [SerializeField] private UnityEvent onTrackedImageTracking;

    // Start is called before the first frame update
    void Start()
    {
        trackedImage = GetComponent<ARTrackedImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited) {
            Debug.Log("Tracked image is now limited");
            onTrackedImageLimited.Invoke();
        }
        else if(trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking) {
            onTrackedImageTracking.Invoke();
        }
    }
}
