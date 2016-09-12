﻿using UnityEngine;
using System.Collections.Generic;
using System.Text;

public abstract class Vid_Query : Vid_Object {

    public Vid_DB_Table table;
    public List<Vid_DB_Col> cols;

    public StringBuilder queryText;
    public string t;

    public override void Awake()
    {
        base.Awake();
        cols = new List<Vid_DB_Col>();
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
