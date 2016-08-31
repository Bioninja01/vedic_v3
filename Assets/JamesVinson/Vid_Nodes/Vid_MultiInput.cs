using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System;

public class Vid_MultiInput : Vid_Object {

    public VidData_Type typeOfInputs;
    int inputSize = 1;

    public Vid_MultiInput(){
        typeOfInputs = VidData_Type.NUM;
    }

    public override void Awake() {
        base.Awake();
        acceptableInputs = new VidData_Type[1];
            acceptableInputs[0] = typeOfInputs;
        inputs = new Vid_ObjectInputs(inputSize);
        output = new Vid_Data(typeOfInputs, this);
        output.setData("");
    }

    public override bool addInput(Vid_Data data, int index) {
        if (data.getVidData_type() == typeOfInputs ) {
            base.addInput(data, index);
        }
        return false;
    }

    public override void updateData() {
        output.setData(writeInputs());
    }

    public void incromentInputs() {
        inputSize++;
        Vid_ObjectInputs newInputs = new Vid_ObjectInputs(inputSize);
        for(int i =0; i < inputSize - 1; i++) {
            newInputs.setInput_atIndex(inputs.getInput_atIndex(i), i);
        }
        inputs = newInputs;
    }
    public void decromentInputs() {
        if(inputSize > 1) {
            inputSize--;
        }
        Vid_ObjectInputs newInputs = new Vid_ObjectInputs(inputSize);
        for (int i = 0; i < inputSize; i++) {
            newInputs.setInput_atIndex(inputs.getInput_atIndex(i), i);
        }
        inputs = newInputs;
    }
    /*Helper functions*/
    private string writeInputs() {
        StringBuilder sb = new StringBuilder("");
        for (int i =0; i<inputs.getSize();i++) {
            Vid_Data d = inputs.getInput_atIndex(i);
            if (d != null) {
                sb.Append(d.getData());
                if (i < inputs.getSize() - 1) {
                    sb.Append(", ");
                }
            }
        }
        return sb.ToString();
    }

}
