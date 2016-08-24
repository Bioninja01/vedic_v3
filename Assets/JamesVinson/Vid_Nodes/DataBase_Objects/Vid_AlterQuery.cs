using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;

public class Vid_AlterQuery : Vid_Query
{
    enum AlterState
    {
        INSERT,
        DELETE
    }
    AlterState state = AlterState.INSERT;
    Vid_DB_Col col;


    public override void startStringify()
    {
        stringify(queryText);
    }

    public override void stringify(StringBuilder targetString)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("ALTER TABLE ");
        sb.Append(table.tableName);

        switch (state)
        {
            case AlterState.INSERT:
                sb.Append(" ADD COLUMN ");
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
                break;
            case AlterState.DELETE:
                sb.Append(" DROP COLUMN ");
                sb.Append(col.colName + " ");
                break;
        }
        sb.Append(" ;");
    }

    //getters

    //setters
    public void setState_Insert()
    {
        state = AlterState.INSERT;
    }
    public void setState_Delete()
    {
        state = AlterState.INSERT;
    }
    public void setCol(Vid_DB_Col col)
    {
        this.col = col;
    }


}
