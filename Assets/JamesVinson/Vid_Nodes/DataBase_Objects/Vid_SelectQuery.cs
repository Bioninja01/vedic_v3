using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;

public class Vid_SelectQuery : Vid_Query
{
    public bool isStar;
    public bool noRepeted;
    public bool isConditional;

    public Vid_SelectQuery()
    {
        isStar = true;
        isConditional = true;
        noRepeted = false;
    }

    public override void Awake() {
        base.Awake();
        base.output_dataType = VidData_Type.DATABASE_TABLE;
        inputs = new Vid_ObjectInputs(3);
        acceptableInputs = new VidData_Type[3];
            acceptableInputs[0] = VidData_Type.DATABASE_TABLE;
            acceptableInputs[1] = VidData_Type.DATABASE_COL;
            acceptableInputs[2] = VidData_Type.DATABASE_WHERE;
    }

    public override string ToString() {
        StringBuilder sb = new StringBuilder();
        if (inputs.getInput_atIndex(1) == null) {
            sb.Append("SELECT * ");
        }
        else {
            sb.Append("SELECT " + inputs.getInput_atIndex(1).ToString() + " ");
        }
        if (inputs.getInput_atIndex(0) == null) {
            sb.Append("FROM error::NoTable ");
        }
        else {
            sb.Append("FROM " + inputs.getInput_atIndex(0).ToString() + " ");
        }
        if (inputs.getInput_atIndex(2) != null) {
            sb.Append(inputs.getInput_atIndex(3).ToString() + " ");
        }
        sb.Append(" ;");
        return sb.ToString();
    }

    /*String Creation functions*/
    public override void startStringify() {
        stringify(queryText);
    }
    public override void stringify(StringBuilder targetString) {
        updateData();
    }

    /*Builder functions*/
    public override bool addInput(Vid_Object obj, int argumentIndex) {
        // Note: don't change, Table=0,COL=1,Where=2 need to be these value.  
        switch (obj.output_dataType) {
            case VidData_Type.DATABASE_TABLE:
                base.addInput(obj, 0);
                break;
            case VidData_Type.DATABASE_COL:
                base.addInput(obj, 1);
                break;
            case VidData_Type.DATABASE_WHERE:
                base.addInput(obj, 2);
                break;
        }
        return false;
    }

}
