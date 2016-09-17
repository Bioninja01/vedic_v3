using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller_Panel : MonoBehaviour {
    public Transform oldParent;
    public Transform newParent;

    public void moveToParent(Toggle t) {
        if (t.isOn) {
            transform.SetParent(newParent);
            transform.position = newParent.position;
        }
        else {
            transform.SetParent(oldParent);
            transform.position = oldParent.position;
        }
    }

}
