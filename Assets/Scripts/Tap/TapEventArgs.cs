using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEventArgs : EventArgs {
    private Vector2 _position;
    public Vector2 Position{
        get { return this._position; }
        //set { this._position = value; }
    }

    private GameObject _hitObject;
    public GameObject HitObject{
        get { return this._hitObject; }
    }

    public TapEventArgs(Vector2 position, GameObject hitObject = null) {
        this._position = position;
        this._hitObject = hitObject;
    }
    
}
