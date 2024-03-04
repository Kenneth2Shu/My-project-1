using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SwitchCamera : MonoBehaviour {
    [SerializeField] private ARCameraManager _CameraManager;

    // Start is called before the first frame update
    void Start()
    {
        if(_CameraManager == null) {
            _CameraManager = GameObject.FindFirstObjectByType<ARCameraManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSwitch() {
        CameraFacingDirection dir = _CameraManager.currentFacingDirection;
        if(dir == CameraFacingDirection.World) {
            _CameraManager.requestedFacingDirection = CameraFacingDirection.User;
        }
        else {
            _CameraManager.requestedFacingDirection = CameraFacingDirection.World;
        }
    }
}
