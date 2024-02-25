using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour {
    [SerializeField] List<ARAgent> agents;

    // Start is called before the first frame update
    void Start() {
        agents = new List<ARAgent>(GetComponentsInChildren<ARAgent>());
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo)) {
                if(hitInfo.collider.CompareTag("Plane")) {
                    MoveAllAgents(hitInfo.point);
                }
            }
        }
    }

    public void MoveAllAgents(Vector3 position) {
        foreach(ARAgent agent in agents) {
            agent.MoveAgent(position);
        }
    }

    public void StopAllAgents() {
        foreach(ARAgent agent in agents) {
            agent.StopAgent();
        }
    }
}
