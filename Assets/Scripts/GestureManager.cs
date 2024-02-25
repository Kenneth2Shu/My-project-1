using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureManager : MonoBehaviour
{//singleton
    public static GestureManager Instance;
    private Touch _trackedFinger1;
    private Touch _trackedFinger2;
    private Touch[] _trackedFinger = new Touch[2];
    //change to touch array
    //btw Touch class has a property called rawPosition which is similar to startPosition we are using here
    private float _gestureTime;
    private Vector2 _gestureDelta; //to keep tracking of finger tap even after
    private Vector2 _startPoint = Vector2.zero;
    private Vector2 _endPoint = Vector2.zero;

    [SerializeField]
    private TapProperty _tapProperty;
    public EventHandler<TapEventArgs> OnTap;//needs using system

    [SerializeField]
    private DragProperty _dragProperty;
    public EventHandler<DragEventArgs> OnDrag;


    //to check if it's a tap
    private void checkTapEvent() {
        if (this._gestureTime <= this._tapProperty.Time && Vector2.Distance(this._startPoint, this._endPoint) < (this._tapProperty.MaxDistance * Screen.dpi)) {//compares the time elapsed by using getter, and also distance between start and end based on distance threshold percentage times the screen's size or dpi
            this.FireTapEvent();//user taps here, passed parameter used to be this._trackedFinger.position
        }
    }

    private void FireTapEvent() {//to be called by update after satisfying certain parameters, originally had vector2 tapPosition as parameter
        Debug.Log("Screen Tap lol");
        /*
        or tapEventArgs
        */
        
        GameObject hitObject = null;
        Ray ray = Camera.main.ScreenPointToRay(this._startPoint);//shoots a ray from where we start the tap
        RaycastHit hit;//to store whether or not we hit smthing

        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            hitObject = hit.collider.gameObject;
        }

        TapEventArgs args = new TapEventArgs(this._startPoint, hitObject);
        if(this.OnTap != null) {
            this.OnTap(this, args);
        }

        if(hitObject!= null) {
            ITappable handler = hitObject.GetComponent<ITappable>();
            if(handler != null) {
                handler.OnTap(args);
            }
        }

        //TapEventArgs tapEventArgs = new TapEventArgs(this._startPoint);
        //this.OnTap(this, tapEventArgs);
        //this.OnTap(this, new TapEventArgs(tapPosition));//this is the sender
    }//sends the event that it was tapped

    private void CheckDrag() {
        Debug.Log("Draggy");
        if(this._gestureTime >= this._dragProperty.Time) {//
            this.FireDragEvent();
            Debug.Log("Draggy lol");
        }
    }

    private void FireDragEvent() {
        Debug.Log("DRAG");
        GameObject hitObject = null;
        Ray ray = Camera.main.ScreenPointToRay(this._trackedFinger[0].position);//shoots a ray from where we are dragging the finger currently
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            if(hit.collider.gameObject.tag == "Beacon") {
                hitObject = hit.collider.gameObject;
            }
        }
        DragEventArgs args = new DragEventArgs(this._trackedFinger[0], hitObject);

        if(this.OnDrag != null) {
            this.OnDrag(this, args);
        }
        if(hitObject != null) {
            IDragable handler = hitObject.GetComponent<IDragable>();
            if(handler != null) {
                handler.OnDrag(args);
            }
        }
    }

    private void CheckSingleFingerInput() {
        this._trackedFinger[0] = Input.GetTouch(0);
        switch(this._trackedFinger[0].phase) {
            case TouchPhase.Began:
                this._startPoint = this._trackedFinger[0].position;
                this._gestureTime = 0;
                break;

            case TouchPhase.Ended://where we decide if it is a tap or not
                this._endPoint = this._trackedFinger[0].position; //to check distance between start and end

                this.checkTapEvent();
                //this.CheckSwipe();

                //to check time elapsed
                break;

            default:
                this._gestureTime += Time.deltaTime;//if not ending yet it will keep tracking time elapsed
                this.CheckDrag();//here cuz it will continuously do it while holding down the finger
                break;
        }
        
    }

    //returns locations of finger in previous frame, helper func
    private Vector2 GetPreviousPoint(Touch finger) {
        return finger.position - finger.deltaPosition;//current position minus change of positions in between frames
    }

    //helper method for 
    private GameObject GetHitObject(Vector2 ScreenPoint) {
        GameObject hitObject = null;
        Ray ray = Camera.main.ScreenPointToRay(ScreenPoint);
        RaycastHit hit;//to store whether or not we hit smthing

        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            hitObject = hit.collider.gameObject;
        }
        return hitObject;
    }

    private Vector2 GetMidPoint(Vector2 pointA, Vector2 pointB) {
        return (pointA + pointB) / 2;
    }
 
    private void CheckDualFingerInput() {
        //if both fingers phases touchphase.move, call check pan
        this._trackedFinger[0] = Input.GetTouch(0);
        this._trackedFinger[1] = Input.GetTouch(1);
        //if(this._trackedFinger[0].phase == TouchPhase.Moved && this._trackedFinger[1].phase == TouchPhase.Moved) {
        //    CheckPan();
        //}

        switch(this._trackedFinger[0].phase, this._trackedFinger[1].phase) {//multiple conditions for switch use ,
            case (TouchPhase.Moved, TouchPhase.Moved)://matches the diff switch conditions
                //this.CheckPan();
                break;
        }

        //if any finger's phase is touch.moved, call check spread, separate func
        //cant chain this with the previous switch case since once the first case is got, they dont go on to the next
        //note: _ means default value
        switch(this._trackedFinger[0].phase, this._trackedFinger[1].phase) {//so either finger 1 is moving then dont care about finger 2, or vice versa
            case (TouchPhase.Moved, _)://fall through so if 1st finger is moving and we dont care abt 2nd finger
            case (_, TouchPhase.Moved)://if 2nd finger is moving and we dont care abt 1st finger
                //this.CheckSpread();
                //this.CheckRotate();
                break;
        }

        //if any of the fingers or both have touch.moved call CheckRotate

    }

    private GameObject GetHitObject() {
        //for swipe and tap, start position
        //for drag real time so tracked finger position
        GameObject hitObject = null;
        Ray ray = Camera.main.ScreenPointToRay(this._trackedFinger[0].position);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            hitObject = hit.collider.gameObject;
        }
        return hitObject;
    }

    //lifecycle methods
    //calls other funcs in order 
    //ex. update
    //awake is at the very start of the cycle, even before start
    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) {
            this._trackedFinger[0] = Input.GetTouch(0);
            switch(Input.touchCount) {
                case 1:
                    CheckSingleFingerInput();
                    break;
                case 2:
                    CheckDualFingerInput();
                    break;
            }
            
        }
    }
}