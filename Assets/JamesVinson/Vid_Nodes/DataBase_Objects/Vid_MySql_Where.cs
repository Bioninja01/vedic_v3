using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;

public class Vid_MySql_Where : Vid_Object
{

    public Vid_MySql_Where() {
        output_dataType = VidData_Type.DATABASE_CALUSE;
    }

    public override void Awake() {
        base.Awake();
        inputs = new Vid_ObjectInputs(2);
        acceptableInputs = new VidData_Type[2];
            acceptableInputs[0] = VidData_Type.BOOL;
            acceptableInputs[1] = VidData_Type.DATABASE_CALUSE;
    }
    public override string ToString() 
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("WHERE ");
        if (inputs.getInput_atIndex(0) != null) {
            sb.Append(inputs.getInput_atIndex(0).ToString());
        }
        sb.Append(Environment.NewLine);
        if(inputs.getInput_atIndex(1) != null) {
            sb.Append(inputs.getInput_atIndex(1).ToString());
        }
        return sb.ToString();
    }

}
