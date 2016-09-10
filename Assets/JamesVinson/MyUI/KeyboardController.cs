using UnityEngine;
using System.Collections;
using System.Text;

public class KeyboardController : MonoBehaviour {
    StringBuilder sb = new StringBuilder("");
    int index = 0;

    public void buildString(string s) {
        sb.Append(s);
        index++;
    }

    public override string ToString() {
        return sb.ToString();
    }

    public void backSpace() {
        if (sb.Length > 0) {
            sb.Length--;
        } 
    }

    public void clearText() {
        sb = new StringBuilder();
        index = 0;
    }

}
