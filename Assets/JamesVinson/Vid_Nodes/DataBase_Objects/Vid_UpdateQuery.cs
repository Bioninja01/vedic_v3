using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;


public class Vid_UpdateQuery : Vid_Query
{

    private string writeValues()
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;

        foreach (Vid_DB_Col c in cols)
        {
            sb.Append(c.colName + " = '" + c.ToString()+"'");
            if (count < cols.Count - 1)
            {
                sb.Append(", ");
                count++;
            }
        }
        return sb.ToString();
    }
}
