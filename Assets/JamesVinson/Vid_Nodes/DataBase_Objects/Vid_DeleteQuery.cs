using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;

public class Vid_DeleteQuery : Vid_Query
{
    public override void startStringify()
    {
        stringify(queryText);
    }

    public override void stringify(StringBuilder targetString)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("DELETE FROM ");
        sb.Append(table.tableName);
        sb.Append(";");
    }

}
