using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;

public class Vid_DB_Table : Vid_Object
{
    public string tableName;

    public new void Awake() 
    {
        base.Awake();
        acceptableInputs = new VidData_Type[1];
            acceptableInputs[0] = VidData_Type.DATABASE_QUERY;
    }

    public override bool addInput(Vid_Data data, int argumentIndex) {
        switch (data.getVidData_type()) {
            case VidData_Type.DATABASE_QUERY:
                if(base.addInput(data, argumentIndex)) {
                    StringBuilder sb = new StringBuilder(data.getData());
                    sb.Replace("$table::PLACEHOLDER", tableName);
                    output.setData(sb.ToString());
                }
                break;
        }
        return false;
    }
    public override bool removeInput(int argumentIndex) {
        if (base.removeInput(argumentIndex)) {
            output.setData("");
        }
        return base.removeInput(argumentIndex);
    }

    public void stringify(StringBuilder targetString) { }


}
