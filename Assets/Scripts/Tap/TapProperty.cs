using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]//needs using system
//makes it visible in the inspector

public class TapProperty {
    [SerializeField]
    private float _time = 0.7f;//how long pressed to be considered a tap, aka threwshlohd
    public float Time {//another version of getters and setters
        get { return this._time; }
        set { this._time = value; }//value is keyword to be equated
    }//basically a public version of the private field that can get and set its value
    //classic version can also work

    [SerializeField]
    private float _maxDistance = 0.1f;//from initial tap location to consider a tap
    public float MaxDistance {
        get { return this._maxDistance; }
        set { this._maxDistance = value; }
    }
}
