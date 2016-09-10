using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyboardText : MonoBehaviour {
    public KeyboardController kc;
    public Text t;
	
	// Update is called once per frame
	void Update () {
	    if(t != null) {
            if(kc != null) {
                t.text = kc.ToString();
            }
        }
	}
}
