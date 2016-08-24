using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;

public abstract class Vid_Object : MonoBehaviour, Inputable
{

    protected Vid_ObjectInputs inputs;
    protected Vid_Data output;
    protected VidData_Type[] acceptableInputs;

    protected Vid_TokenFactory tokenFactory;

    public void Awake()
    {
        tokenFactory = Vid_TokenFactory.getInstance();
    }

    public virtual void updateData() {}

    /*Builder Functions*/
    public virtual bool addInput(Vid_Data data, int argumentIndex) {
        return inputs.setInput_atIndex(data,argumentIndex);
    }
    public virtual bool removeInput( int argumentIndex) {
        if(inputs != null) {
            return inputs.removeInput_atIndex(argumentIndex);
        }
       return false;
    }

    /* Getters */
    public virtual Vid_Data getOutput() { return output; }
    public VidData_Type[] getAcceptableInputs() {
        return acceptableInputs;
    }

}
