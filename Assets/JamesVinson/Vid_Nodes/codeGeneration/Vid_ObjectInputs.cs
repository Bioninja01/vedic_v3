using UnityEngine;
using System.Collections;

public class Vid_ObjectInputs {
    public Vid_Data[] left;
    int maxsize;

    public Vid_ObjectInputs(int numOf_Inputs)
    {
        maxsize = numOf_Inputs;
        left = new Vid_Data[numOf_Inputs];
    }

    public bool isInputFull()
    {
        if(left.Length == maxsize)
        {
            return true;
        }
        return false;
    }


    public bool removeInput_atIndex(int index) {
        if ((index > -1) && (index < maxsize)) {
            left[index] = null;
            return true;
        }
        return false;
    }

    public Vid_Data getInput_atIndex(int index)
    {
        if(index > -1 && index < maxsize)
        {
            return left[index];
        }
        return null;
    }

    public bool setInput_atIndex(Vid_Data data, int index) {
        if ((index > -1) && (index < maxsize)) {
            left[index] = data;
            return true;
        }
        return false;
    }
}
