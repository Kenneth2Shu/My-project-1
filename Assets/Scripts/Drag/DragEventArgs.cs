using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DragEventArgs : EventArgs
{
    private Touch _trackedFinger;
    public Touch TrackedFinger {
        get { return this._trackedFinger; }
    }

    private GameObject _hitObject;
    public GameObject HitObject {
        get { return this._hitObject; }
    }

    public DragEventArgs(Touch trackedFinger, GameObject hitObject) {
        this._trackedFinger = trackedFinger;
        this._hitObject = hitObject;
    }
}
