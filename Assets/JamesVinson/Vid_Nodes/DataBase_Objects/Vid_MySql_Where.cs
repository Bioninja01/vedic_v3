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
        acceptableInputs = new VidData_Type[2];
            acceptableInputs[0] = VidData_Type.BOOL;
            acceptableInputs[1] = VidData_Type.DATABASE_CALUSE;
        inputs = new Vid_ObjectInputs(2);
    }
    public override string ToString() 
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("WHERE");
        sb.Append(Environment.NewLine);
        
        return sb.ToString();
    }

}
