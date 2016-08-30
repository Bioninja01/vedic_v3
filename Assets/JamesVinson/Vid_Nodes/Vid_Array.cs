using UnityEngine;
using System.Collections;

public class Vid_Array : Vid_Object {

    public VidData_Type typeOfArray = VidData_Type.NUM;

    public override void Awake() {
        base.Awake();
        inputs = new Vid_ObjectInputs();
        output = new Vid_Data(typeOfArray, this);
        output.setData("");
    }
}
