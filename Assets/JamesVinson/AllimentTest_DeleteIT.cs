using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

using System.Collections;

public class AllimentTest_DeleteIT : MonoBehaviour {
    public Text t;
    
	// Use this for initialization
	void Start () {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i<3; i++) {
            sb.AppendLine(string.Format("{0,"+ TabTool.numberOfSpaces()+"}", "public void Bob()"));
            TabTool.tabindex++;
            sb.AppendLine(string.Format("{0," + TabTool.numberOfSpaces() + "} {1,10}", ":1", ":2"));
            for(int x=0; x < 3; x++) {
                sb.AppendLine(string.Format("{0," + TabTool.numberOfSpaces() + "} {1,10}", ":1", ":2"));
            }
            TabTool.tabindex--;
        }
        t.text = sb.ToString();
	}
}
