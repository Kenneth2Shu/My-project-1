using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AnchorPlacer : MonoBehaviour
{
    ARAnchorManager anchorManager;

    [SerializeField] private GameObject prefabA;
    [SerializeField] private GameObject prefabB;
    [SerializeField] private GameObject prefabC;

    [SerializeField] private GameObject prefabToAnchor;
    [SerializeField] private float forwardOffset = 0.6f;
    public float ForwardOffset {
        set { this.forwardOffset = value; }
    }

    [SerializeField] private List<GameObject> gameObjectList;

    [SerializeField] private ARRaycastManager raycastManager;

    private List<ARRaycastHit> raycastHitList;

    [SerializeField] private GameObject levelPrefab;

    private bool levelHasSpawned;

    void Start() {
        levelHasSpawned = false;
        gameObjectList = new();
        raycastHitList = new();
        anchorManager = GetComponent<ARAnchorManager>();
        if(prefabToAnchor == null) {
            prefabToAnchor = prefabA;
        }
    }

    void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            GameObject hitObject = null;
            //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);//shoots a ray from where we start the tap
            RaycastHit hit;//to store whether or not we hit smthing

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //if(Physics.Raycast(ray, out hitInfo)) {
            //    if(hitInfo.collider.gameObject.CompareTag("Destructible")) {
            //        Destroy(hitInfo.collider.gameObject);
            //        return;
            //    }
            //}

            if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                hitObject = hit.collider.gameObject;
                if(hitObject.tag == "Destructible") {
                    Debug.LogWarning("Sayonara.");
                    gameObjectList.Remove(hitObject);
                    Destroy(hitObject);
                }
            }

            if(raycastManager.Raycast(ray, raycastHitList, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon)) {
                foreach(ARRaycastHit hitThing in raycastHitList) {
                    if(hitThing.trackable is ARPlane plane && plane.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalUp) {
                        AnchorObject(hitThing.pose.position);
                        break;
                    }
                }
            }

            //if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            //    hitObject = hit.collider.gameObject;
            //    if(hitObject.tag != "Plane") {
            //        Debug.LogWarning("Sayonara.");
            //        gameObjectList.Remove(hitObject);
            //        Destroy(hitObject);
            //    }
            //}
            //else if(raycastManager.Raycast(Input.GetTouch(0).position, raycastHitList, TrackableType.PlaneWithinPolygon)) {
            //    Vector3 spawnPos = Camera.main.ScreenPointToRay(Input.GetTouch(0).position).GetPoint(forwardOffset);
            //    AnchorObject(spawnPos);
                //foreach(ARRaycastHit raycastHitThing in raycastHitList) {
                //    if(raycastHitThing.pose.up == Vector3.up) {
                //        Debug.Log("Horizontal plane detected.");
                //        AnchorObject(raycastHitList[0].pose.position);
                //    }
                    //if(HitPlane(raycastHitThing)) {
                        //
                    //}
                //}
            //}
            //else {
                //Vector3 spawnPos = Camera.main.ScreenPointToRay(Input.GetTouch(0).position).GetPoint(forwardOffset);
                //AnchorObject(spawnPos);
            //}        
        }
    }

    public void AnchorObject(Vector3 worldPos) {
        if(prefabToAnchor.tag == "Level") {
            if(levelHasSpawned == false) {
                GameObject newAnchor = new GameObject("NewAnchor");
                newAnchor.transform.parent = null;
                newAnchor.transform.position = worldPos;
                newAnchor.AddComponent<ARAnchor>();

                GameObject obj = Instantiate(prefabToAnchor, newAnchor.transform);
                obj.transform.localPosition = Vector3.zero;
                Debug.LogWarning(obj.name);
                //gameObjectList.Add(obj);
                gameObjectList.Add(newAnchor);
                levelHasSpawned = true;
            }
            else {
                Debug.LogWarning("Level has already spawned");
            }
        }
        else {
            GameObject newAnchor = new GameObject("NewAnchor");
            newAnchor.transform.parent = null;
            newAnchor.transform.position = worldPos;
            newAnchor.AddComponent<ARAnchor>();

            GameObject obj = Instantiate(prefabToAnchor, newAnchor.transform);
            obj.transform.localPosition = Vector3.zero;
            Debug.LogWarning(obj.name);
            //gameObjectList.Add(obj);
            gameObjectList.Add(newAnchor);
        }
    }

    public void LoadPrefabA() {
        prefabToAnchor = prefabA;
    }

    public void LoadPrefabB() {
        prefabToAnchor = prefabB;
    }

    public void LoadPrefabC() {
        prefabToAnchor = prefabC;
    }

    public void Order66() {
        Debug.Log("The time has come... execute order 66");
        Debug.Log("It will be done milord.");
        foreach(GameObject AGameObject in gameObjectList) {
        //for(int i = 0; i < gameObjectList.Count; i++) {
            //Debug.LogWarning(gameObjectList[i].gameObject.transform.parent);
            //Destroy(gameObjectList[i].gameObject.transform.parent);
            Debug.LogWarning("Jedi " + AGameObject.name +" is now dead.");
            Destroy(AGameObject);
        }
        gameObjectList.Clear();
    }

    private bool HitPlane(ARRaycastHit hit) {
        if(hit.trackable is ARPlane plane && hit.pose.up == Vector3.up && plane.alignment == PlaneAlignment.HorizontalUp) {
            Debug.Log("Horizontal plane detected.");
            return true;
        }
        else {
            return false;
        }
    }
}
