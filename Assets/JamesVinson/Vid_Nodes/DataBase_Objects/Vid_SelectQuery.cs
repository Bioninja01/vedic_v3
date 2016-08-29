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

    public Vid_SelectQuery() : base()
    {
        isStar = true;
        isConditional = true;
        noRepeted = false;
    }

    public override void Awake() {
        base.Awake();
        acceptableInputs = new VidData_Type[3];
            acceptableInputs[0] = VidData_Type.DATABASE_COL;
            acceptableInputs[1] = VidData_Type.DATABASE_TABLE;
            acceptableInputs[2] = VidData_Type.DATABASE_WHERE;
    }
    
    /*String Creation functions*/
    public override void startStringify() {
        stringify(queryText);
    }
    public override void stringify(StringBuilder targetString) {
        StringBuilder sb = new StringBuilder();
        sb.Append("SELECT ");

        if (noRepeted) {
            sb.Append("DISTINCT ");
        }
        if (base.cols.Count == 0) {
            sb.Append("* ");
        }
        else {
            sb.Append(writeColumns());
        }
        sb.Append("FROM " + table.tableName + " ");

        if (isConditional && (base.sequence != null)) {
            sb.Append(" " + tokenFactory.generateToken() + " ");
            sb.Append(";");
            queryText = sb;
            //base.sequence.stringify(queryText);
        }
        else {
            sb.Append(";");
            queryText = sb;
        }
    }

    /*Builder functions*/
    public override bool addInput(Vid_Data data, int argumentIndex) {
        switch (data.getVidData_type()) {
            case VidData_Type.DATABASE_COL:
                base.addInput(data, argumentIndex);
                addCol( (Vid_DB_Col) data.getVid_object());
                break;
            case VidData_Type.DATABASE_TABLE:
                base.addInput(data, argumentIndex);
                setTable((Vid_DB_Table) data.getVid_object());
                break;
            case VidData_Type.DATABASE_WHERE:
                base.addInput(data, argumentIndex);
                break;
        }
        return false;
    }
    public override bool removeInput(int argumentIndex) {
        Vid_Data d = inputs.getInput_atIndex(argumentIndex);
        if(d == null) { return false; }
        switch (d.getVidData_type()) {
            case VidData_Type.DATABASE_COL:
                base.removeInput(argumentIndex);
                Vid_DB_Col c = (Vid_DB_Col)d.getVid_object();
                removeCol(c);
                break;
            case VidData_Type.DATABASE_TABLE:
                base.removeInput(argumentIndex);
                setTable(null);
                break;
            case VidData_Type.DATABASE_WHERE:
                base.removeInput(argumentIndex);
                break;
        }
        return false;
    }

    /*Helper Functions*/
    private  string writeColumns()
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;
        foreach (Vid_DB_Col c in cols)
        {
            sb.Append(c.getColName());
            if (count < cols.Count - 1)
            {
                sb.Append(", ");
                count++;
            }
        }
        return sb.ToString();
    }
}
