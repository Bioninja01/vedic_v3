using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;

public class Vid_DB_Col : Vid_SequenceableObject {


    private bool isSetable = false;
    public string colName;
    public MySql_colTypes type = MySql_colTypes.MYSQL_INT;
    private bool NotNull;
    private int charvarNumber = 1;

    public new void Awake() 
    {
        base.Awake();
        NotNull = false;
    }

    public override void stringify(StringBuilder targetString)
    {
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


    public bool isNotNull(){ return NotNull; }
    public string getColName() { return colName; }
    public int getCarVarNumber() { return charvarNumber; }
    public bool getSetable() { return isSetable; }


    public void set_NotNull(bool b){this.NotNull = b; }
    public void setColName(string s){this.colName = s;}
    public void setCarVarNumber(int i) { this.charvarNumber = i; }
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
