using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TrackedImageObjectHandler : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float yOffset = 0.5f;

    public void OnTrackedImageChange(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs) {
        foreach(var image in eventArgs.added) {
            //handle added event
            Debug.Log("Tracked new image: " + image.referenceImage.name);
            //spawn cube here
            //instantiate
            //GameObject _cube = GameObject.Instantiate(_cubePrefab);
            //anchor to image trackable
            //_cube.transform.parent = image.transform;
            //_cube.transform.localPosition = new Vector3(0, yOffset, 0);
        }

        foreach(var image in eventArgs.updated) {
            //handle updated event
            Debug.Log("Updated image: " + image.referenceImage.name);
            //if(image.trackingState == TrackingState.Limited) {
                //
            //}
        }

        foreach(var image in eventArgs.removed) {
            //handle removed event
            Debug.Log("Removed image: " + image.referenceImage.name);
        }
    }
}
