using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;

public class Vid_DB_Col : Vid_Object {

    public string colName;

    public MySql_colTypes type = MySql_colTypes.MYSQL_INT;

    private bool isSetable = false;
    private bool NotNull;
    private int charvar_Number = 1;

    public new void Awake() 
    {
        base.Awake();
        NotNull = false;
        acceptableInputs = new VidData_Type[2];
            acceptableInputs[0] = VidData_Type.DATABASE_COL;
            acceptableInputs[1] = VidData_Type.DATABASE_TABLE;
    }
    public void toggleMySql_ColType()
    {
        switch (type)
        {
            case MySql_colTypes.MYSQL_INT:
                type = MySql_colTypes.MYSQL_FLOAT;
                break;
            case MySql_colTypes.MYSQL_FLOAT:
                type = MySql_colTypes.MYSQL_DOUBLE;
                break;
            case MySql_colTypes.MYSQL_DOUBLE:
                type = MySql_colTypes.MYSQL_CHAR;
                break;
            case MySql_colTypes.MYSQL_CHAR:
                type = MySql_colTypes.MYSQL_BLOB;
                break;
            case MySql_colTypes.MYSQL_BLOB:
                type = MySql_colTypes.MYSQL_TIMESTAMP;
                break;
            case MySql_colTypes.MYSQL_TIMESTAMP:
                type = MySql_colTypes.MYSQL_VARCHAR;
                break;
            case MySql_colTypes.MYSQL_VARCHAR:
                type = MySql_colTypes.MYSQL_ENUM;
                break;
            case MySql_colTypes.MYSQL_ENUM:
                type = MySql_colTypes.MYSQL_INT;
                break;
            default:
                type = MySql_colTypes.MYSQL_INT;
                break;
        }
    }

    public override bool addInput(Vid_Data data, int argumentIndex) {
        switch (data.getVidData_type()) {
            case VidData_Type.DATABASE_QUERY:
                Vid_Query q = (Vid_Query)data.getVid_object();
                q.addCol(this);
                q.formatColData();
                base.addInput(data, argumentIndex);
                break;
        }
        return false;
    }

    public override void updateData() {
        Vid_Object obj = base.inputs.getInput_atIndex(0).getVid_object();
        if(obj != null) {
            obj.updateData();
        }
    }
    /*Getters*/
    public bool isNotNull(){ return NotNull; }
    public string getColName() { return colName; }
    public int getCarVarNumber() { return charvar_Number; }
    public bool getSetable() { return isSetable; }

    /*Setters*/
    public void set_NotNull(bool b){this.NotNull = b; }
    public void setColName(string s){this.colName = s;}
    public void setCarVarNumber(int i) { this.charvar_Number = i; }
    public void setSetable(bool b) {
        this.isSetable = b;
        if (b)
        {
            output = new Vid_Data(VidData_Type.DATABASE_COL, this);
            output.setData("value");
        }
        else
        {
            output = null;
        }
    }
}
