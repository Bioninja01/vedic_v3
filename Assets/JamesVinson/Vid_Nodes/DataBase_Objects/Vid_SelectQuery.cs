using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;

public class Vid_SelectQuery : Vid_Query
{
    public bool isStar;
    public bool isRepeted;
    public bool isConditional;

    public Vid_SelectQuery() : base()
    {
        isStar = true;
        isConditional = true;
        isRepeted = false;
    }

    public override void startStringify()
    {
        stringify(queryText);
    }

    public override void stringify(StringBuilder targetString)
    {
        //StringBuilder sb = new StringBuilder();
        //sb.Append("SELECT ");

        //if (isRepeted)
        //{
        //    sb.Append("DISTINCT ");
        //}
        //if (isStar)
        //{
        //    sb.Append("* ");
        //}
        //else
        //{
        //    sb.Append(writeColumns());
        //}
        //sb.Append("FROM " + table.tableName +" ");

        //if (isConditional && (base.sequence != null))
        //{
        //    sb.Append(" "+tokenFactory.generateToken()+" ");
        //    sb.Append(";");
        //    queryText = sb;
        //    base.sequence.stringify(queryText);
        //}
        //else
        //{
        //    sb.Append(";");
        //    queryText = sb;
        //}
    }

    public string writeColumns()
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
