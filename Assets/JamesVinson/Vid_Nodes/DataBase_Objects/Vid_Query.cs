using UnityEngine;
using System.Collections.Generic;
using System.Text;

public abstract class Vid_Query : Vid_Expression {

    public Vid_DB_Table table;
    public List<Vid_DB_Col> cols;

    public StringBuilder queryText;
    public string t;

    public override void Awake()
    {
        base.Awake();
        inputs = new Vid_ObjectInputs();
        cols = new List<Vid_DB_Col>();
        output = new Vid_Data(VidData_Type.DATABASE_QUERY, this);
    }

    public virtual void formatColData() { }

    //builders
    public bool addCol(Vid_DB_Col c)
    {
        if (c.getSetable())
        {
            cols.Add(c);
            return true;
        }
        else return false;
    }
    public void removeCol(Vid_DB_Col c)
    {
        cols.Remove(c);
    }

    //getters
    public Vid_DB_Table getTable()
    {
        return table;
    }
    public StringBuilder getQueryText()
    {
        return queryText;
    }
   
    //setters
    public void setTable(Vid_DB_Table table)
    {
        this.table = table;
    }
}
