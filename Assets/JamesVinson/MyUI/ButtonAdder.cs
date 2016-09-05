using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

public class ButtonAdder : MonoBehaviour {

    public Vid_MultiInput mInput;
    public RectTransform button;
    public GridLayoutGroup layout;
    public List<RectTransform> buttons; 
        
    public void addButton_toLayout() {
        RectTransform rt =(RectTransform)Instantiate(button, new Vector3(0, 0, 0), Quaternion.identity);
        InputButton input = rt.GetComponent<InputButton>();
        input.input_dataType = mInput.output_dataType;
        input.vidObj = mInput;
        rt.SetParent(layout.transform,false);
        buttons.Add(rt);
        input.argumentIndex = buttons.Count;
        mInput.incromentInputs();
    }

    public void removeButton_fromLayout() {
        GameObject.Destroy(buttons[buttons.Count - 1].gameObject);
        buttons.RemoveAt(buttons.Count - 1);
        mInput.decromentInputs();
    }
}
