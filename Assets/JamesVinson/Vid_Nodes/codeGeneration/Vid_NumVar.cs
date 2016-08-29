using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;

public class Vid_NumVar : Vid_Variable {

    public Vid_Number vid_number;
    public String varName;

    public override void Awake()
    {
        base.Awake();
        vid_number.setUpOutput(varName);
    }

    public String getName() { return varName; }
    public void setName(String name) { this.varName = name; }

    public Vid_Number getVid_number() { return vid_number; }
    public void reSetVid_number(String name)
    {
        this.varName = name;
        this.vid_number = new Vid_Number();
        vid_number.setUpOutput(name);
    }

    public new Vid_Data getOutput(){ return vid_number.getOutput(); }

}
