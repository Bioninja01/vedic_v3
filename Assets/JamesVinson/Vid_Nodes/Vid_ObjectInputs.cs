﻿using UnityEngine;
using System.Collections.Generic;

public class Vid_ObjectInputs {
    int maxsize;
    public Vid_Data[] inputs;
    
    public Vid_ObjectInputs(int numOf_Inputs)
    {
        maxsize = numOf_Inputs;
        inputs = new Vid_Data[numOf_Inputs];
    }

    /*Builders*/
    public bool removeInput_atIndex(int index) {
        /*Used for CodeGenereation*/
        if(inputs == null) { return false; }

        if ((index > -1) && (index < maxsize)) {
            inputs[index] = null;
            return true;
        }
        return false;
    }
    
    /*Getters*/
    public Vid_Data getInput_atIndex(int index)
    {
        if (inputs == null) { return null; }
        if (index > -1 && index < maxsize) {
            return inputs[index];
        }
        return null;
    }
    public int getSize() {
        return maxsize;
    }
  
    /*Setters*/
    public bool setInput_atIndex(Vid_Data data, int index) {
        if (inputs == null) { return false; }
        if ((index > -1) && (index < maxsize)) {
            inputs[index] = data;
            return true;
        }
        return false;
    }
}
