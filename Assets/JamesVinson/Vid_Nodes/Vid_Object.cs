using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;

public abstract class Vid_Object : MonoBehaviour, Inputable
{
    protected Vid_ObjectInputs inputs;
    protected VidData_Type[] acceptableInputs;
    public VidData_Type output_dataType;

    protected Vid_TokenFactory tokenFactory;

    public virtual void Awake()
    {
        tokenFactory = Vid_TokenFactory.getInstance();
    }
    /*Builder Functions*/
    public virtual void updateData() { }
    public virtual bool addInput(Vid_Object obj, int argumentIndex) {
        return inputs.setInput_atIndex(obj,argumentIndex);
    }
    public virtual bool removeInput( int argumentIndex) {
        if(inputs != null) {
            return inputs.removeInput_atIndex(argumentIndex);
        }
       return false;
    }
   
    /* Getters */
    public VidData_Type[] getAcceptableInputs() {
        return acceptableInputs;
    }

}
