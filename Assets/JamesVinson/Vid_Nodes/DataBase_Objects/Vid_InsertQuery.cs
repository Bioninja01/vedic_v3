using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;

public class Vid_InsertQuery : Vid_Query
{

    public override void startStringify()
    {
        stringify(queryText);
    }

    public override void stringify(StringBuilder targetString)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("INSERT INTO ");
        sb.Append(table.tableName);
        sb.Append("VALUES ( ");
        sb.Append(writeValues());
        sb.Append(" );");
    }

    // helper function
    private string writeValues()
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;

        foreach (Vid_DB_Col c in cols)
        {
            sb.Append(c.colName + " = " + c.getOutput().getData());
            if (count < cols.Count - 1)
            {
                sb.Append(", ");
                count++;
            }
        }
        return sb.ToString();
    }

}
