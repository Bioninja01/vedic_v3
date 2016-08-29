using UnityEngine;
using System.Collections.Generic;

public class Vid_ObjectInputs {
    int maxsize;
    public List<Vid_Data> dataInputs;
    
    public Vid_ObjectInputs() {
        dataInputs = new List<Vid_Data>();
    }
    public Vid_ObjectInputs(int numOf_Inputs)
    {
        maxsize = numOf_Inputs;
        dataInputs = new List<Vid_Data>(numOf_Inputs);
    }

    /*Builders*/
    public bool removeInput_atIndex(int index) {
        if ((index > -1) && (index < maxsize)) {
            dataInputs[index] = null;
            return true;
        }
        return false;
    }
    /*Getters*/
    public Vid_Data getInput_atIndex(int index)
    {
        if(maxsize == 0) {
            if (index > -1 && index < dataInputs.Count) {
                return dataInputs[index];
            }
        }
        else if(index > -1 && index < maxsize) {
            return dataInputs[index];
        }
        return null;
    }
    public bool isInputFull() {
        if (dataInputs.Count == maxsize) {
            return true;
        }
        return false;
    }
    /*Setters*/
    public bool setInput_atIndex(Vid_Data data, int index) {
        if (maxsize == 0) {
            if (index > -1 && index < dataInputs.Count) {
                dataInputs[index] = data;
                return true;
            }
        }
        else if ((index > -1) && (index < maxsize)) {
            dataInputs[index] = data;
            return true;
        }
        return false;
    }
}
