using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;

public class Vid_MySql_Where : Vid_SequenceableObject
{
    Condition condition;

    public override void stringify(StringBuilder targetString)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("WHERE");
        sb.Append(Environment.NewLine);
        switch (condition.conditionType)
        {
            case Condition_Type.LESS:
                sb.Append(condition.col.colName + "<" + condition.data);
                break;
            case Condition_Type.LESS_EQU:
                sb.Append(condition.col.colName + "<=" + condition.data);
                break;
            case Condition_Type.GREATER:
                sb.Append(condition.col.colName + ">" + condition.data);
                break;
            case Condition_Type.GREATER_EQU:
                sb.Append(condition.col.colName + ">=" + condition.data);
                break;
            case Condition_Type.EQU:
                sb.Append(condition.col.colName + "=" + condition.data);
                break;
            case Condition_Type.NOT_EQU:
                sb.Append(condition.col.colName + "!=" + condition.data);
                break;
            default:
                break;
        }
    }

    public void setCondition(Vid_DB_Col col,string data,Condition_Type conditionType)
    {
        condition = new Condition(col,data, conditionType);
    }

    private class Condition
    {
        public Vid_DB_Col col;
        public Condition_Type conditionType;
        public string data;
        public Condition(Vid_DB_Col col, string data, Condition_Type conditionType)
        {
            this.col = col;
            this.data = data;
            this.conditionType = conditionType;
        }
    }
}
