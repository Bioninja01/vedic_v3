using UnityEngine;
using System.Collections.Generic;
using LMWidgets;

public class OutputButton : NodeButton {
    public int outputIndex = 0;
    public ButtonType buttonType = ButtonType.OUTPUT_DATA;

    public Vid_Object vid_obj;

    bool inUse = false;

    public override void buttonPressed()
    {
        if (!inUse)
        {
            if (!ct.currentSeleted())
            {
                setIsUse(true);
                ct.setOutputButton(this);
            }
        }
        else {
            setIsUse(false);
            ct.setOutputButton(null);
        }
    }

    public void addSequence(Vid_SequenceableObject input_seqobj)
    {
        Vid_SequenceableObject seqobj = (Vid_SequenceableObject)vid_obj;
        seqobj.setSequence(input_seqobj, outputIndex);
    }
    public void removeSequence()
    {
        Vid_SequenceableObject seqobj = (Vid_SequenceableObject)vid_obj;
        seqobj.setSequence(null, outputIndex);
    }
    public void setIsUse(bool b)
    {
        this.inUse = b;
    }
}
