﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;

public class Vid_InsertQuery : Vid_Query
{

    public override void Awake() {
        base.Awake();
        base.output_dataType = VidData_Type.DATABASE_TABLE;
        inputs = new Vid_ObjectInputs(2);
        acceptableInputs = new VidData_Type[2];
            acceptableInputs[0] = VidData_Type.DATABASE_TABLE;
            acceptableInputs[1] = VidData_Type.DATABASE_COL;
    }

    public override string ToString() {
        StringBuilder sb = new StringBuilder();
        if (inputs.getInput_atIndex(0) == null) {
            sb.Append("INSERT INTO error::NoTable SET ");
        }
        else {
            sb.Append("INSERT INTO " + inputs.getInput_atIndex(0).ToString() + " SET ");
        }
        if (inputs.getInput_atIndex(1) != null) {
            sb.Append(inputs.getInput_atIndex(1).ToString());
        }
        sb.Append(";");
        return sb.ToString();
    }

    public override bool addInput(Vid_Object obj, int argumentIndex) {
        // Note: don't change, Table=0,COL=1,Where=2 need to be these value.  
        switch (argumentIndex) {
            case 0:
                if (obj.output_dataType == VidData_Type.DATABASE_TABLE) {
                    bool b = base.addInput(obj, 0);
                    return b;
                }
                else {
                    return false;
                }
            case 1:
                if (obj.output_dataType == VidData_Type.DATABASE_COL) {
                    bool b = base.addInput(obj, 1);
                    return b;
                }
                else {
                    return false;
                }
        }
        return false;
    }

    // helper function
    private string writeValues()
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;

        foreach (Vid_DB_Col c in cols)
        {
            sb.Append(c.colName + " = " + c.ToString());
            if (count < cols.Count - 1)
            {
                sb.Append(", ");
                count++;
            }
        }
        return sb.ToString();
    }

}
