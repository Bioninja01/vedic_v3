using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSwitchText : MonoBehaviour {
    GameObject obj;
    public Text text;
    public UnityEngine.UI.Image image;
    public Color OnColor;
    public Color OffColor;

    public void swichText(GameObject go)
    {
        if(go == null){ return; }

        if (obj.Equals(go))
        {
            text.text = "On";
            image.color = OnColor;
        }
        else
        {

        }
    }

}
