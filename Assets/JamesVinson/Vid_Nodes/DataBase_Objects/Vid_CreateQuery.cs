using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;

public class Vid_CreateQuery : Vid_Query
{
    List<Vid_DB_Col> cols_in_table;
    string primaryKey;

    public Vid_CreateQuery()
    {
        cols_in_table = new List<Vid_DB_Col>();
    }

    public override void startStringify()
    {
        stringify(queryText);
    }

    public override void stringify(StringBuilder targetString)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("CREATE TABLE ");
        sb.Append(table.tableName + "(");
        sb.Append(Environment.NewLine);
        sb.Append(writeCols());
        sb.Append(");");
        targetString = sb;
    }

    // helper function
    private string writeCols()
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;

        foreach (Vid_DB_Col col in cols_in_table)
        {
            sb.Append(col.colName + " ");
            switch (col.type)
            {
                case MySql_colTypes.MYSQL_BLOB:
                    sb.Append("BLOB ");
                    break;
                case MySql_colTypes.MYSQL_CHAR:
                    sb.Append("CHAR ");
                    break;
                case MySql_colTypes.MYSQL_VARCHAR:
                    sb.Append("varchar(" + col.getCarVarNumber() + ") ");
                    break;
                case MySql_colTypes.MYSQL_INT:
                    sb.Append("INT ");
                    break;
                case MySql_colTypes.MYSQL_DOUBLE:
                    sb.Append("DOUBLE ");
                    break;
                case MySql_colTypes.MYSQL_FLOAT:
                    sb.Append("FLOAT ");
                    break;
                case MySql_colTypes.MYSQL_TIMESTAMP:
                    sb.Append("TIMESTAMP ");
                    break;
            }
            if (col.isNotNull())
            {
                sb.Append("NOT NULL");
            }
            if (count < cols_in_table.Count - 1)
            {
                sb.Append(", ");
                count++;
            }
            sb.Append(Environment.NewLine);
        }
        sb.Append("PRIMARY KEY (" +primaryKey+")");
        return sb.ToString();
    }

    //builders
    public void addColumn(Vid_DB_Col col)
    {
        cols_in_table.Add(col);
    }
    public void removeColumn(Vid_DB_Col col)
    {
        cols_in_table.Remove(col);
    }

    //getters
    public string getPrimaryKey()
    {
        return primaryKey;
    }
    //setters
    public void setPrimaryKey(String s)
    {
        this.primaryKey = s;
    }

}