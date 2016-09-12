using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Controller_OrderBy : MonoBehaviour, ButtonAdder {

    public RectTransform toggle;
    public VerticalLayoutGroup layout;
    public Vid_OrderBy node;
    public List<RectTransform> toggles;


    public void addButton_toLayout() {
        RectTransform rt = (RectTransform)Instantiate(toggle, new Vector3(0, 0, 0), Quaternion.identity);
        Controller_DescToggle dCon = rt.GetComponentInChildren<Controller_DescToggle>();
        rt.SetParent(layout.transform, false);
        toggles.Add(rt);
        dCon.index = toggles.Count;
        node.incromentInputs();
    }

    public void removeButton_fromLayout() {
        GameObject.Destroy(toggles[toggles.Count - 1].gameObject);
        toggles.RemoveAt(toggles.Count - 1);
        node.decromentInputs();
    }

}
