using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragReceiver : MonoBehaviour
{
    private void OnDrag(object sender, DragEventArgs args) {
        Debug.Log("Drag Detected");
    }

    // Start is called before the first frame update
    private void Start() {
        GestureManager.Instance.OnDrag += this.OnDrag;
    }

    // Update is called once per frame
    private void OnDisable() {
        GestureManager.Instance.OnDrag -= this.OnDrag;
    }
}
