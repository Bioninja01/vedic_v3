using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;

public class Vid_ReturnBool : Vid_Return
{

    public VidBool type;

    public override void Awake()
    {
        base.Awake();
        inputs = new Vid_ObjectInputs(1);
        returnType = Vid_Prefix.Vid_returnValue.BOOL;
    }

    public override bool addInput(Vid_Data data,int index)
    {
        if (data.getVidData_type() == VidData_Type.BOOL)
        {
            return base.addInput(data,index);
        }
        return false;
    }

    public override void stringify(StringBuilder targetString)
    {
        StringBuilder sb = new StringBuilder();   
        if(inputs.getInput_atIndex(0) != null)
        {
            sb.Append("return " + inputs.getInput_atIndex(0).getData() + ";");

        }
        else if(type == VidBool.TRUE)
        {
            sb.Append("return true;");
        }
        else
        {
            sb.Append("return false;");
        }
        String token = tokenFactory.popToken();

        /** Should replace theses steps into a function**/
        targetString.Replace(token, sb.ToString());
    }
    
}
