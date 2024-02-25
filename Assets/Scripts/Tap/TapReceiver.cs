using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapReceiver : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnable1;//so u can directly select it in the inspector
    [SerializeField]
    private GameObject spawnable2;
    [SerializeField]
    private GameObject spawnable3;

    private int nCount = 0;

    private void Spawn(Vector3 spawnPosition) {//vector2 for tap, but object has to be 3d cuz it also has z = distance from camera
        //for spawning
        //call instantiate method
        if(nCount%2 == 0 && nCount%3 != 0) {
            Instantiate(this.spawnable1, spawnPosition, Quaternion.identity);//game object, position, and rotation / quaternion
        }
        else if(nCount%3 == 0) {
            Instantiate(this.spawnable3, spawnPosition, Quaternion.identity);
        }
        else {
            Instantiate(this.spawnable2, spawnPosition, Quaternion.identity);//game object, position, and rotation / quaternion
        }

        nCount++;
    }

    public void OnTap(object sender, TapEventArgs args) {//sterotypical event 
    //btw name of OnTap func and OnTap field sa gesture manager doesnt have to be same name, as long as the parameters are right: object as sender and tapEventArguments as tapEvent
        if(args.HitObject == null) {//so it only spawns when not despawning an object, hitobject == null means it hasnt hit an object
            //ray casting, shooting a ray/laser thru the camera into infinity, shoot ray from tap location
            Ray ray = Camera.main.ScreenPointToRay(args.Position);//uses Position getter
            //spawn object on tap
            this.Spawn(ray.GetPoint(10));//since a ray shoots infinitely, we need to get a specific point
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GestureManager.Instance.OnTap += this.OnTap;//register to gesture manager
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDisable() {
        GestureManager.Instance.OnTap -= this.OnTap;//on disable, remove self from gesture manager
    }
}
