using UnityEngine;
using System.Collections.Generic;
using LMWidgets;

public class OutputButtonV2 : MonoBehaviour {
    public int outputIndex = 0;
    public ButtonType buttonType = ButtonType.OUTPUT_DATA;

    public List<LineRenderer> lines;
    public List<InputButton> inputs;

    public Vid_Object vid_obj;

    bool inUse = false;
    Renderer r;
    ConnectionToolV2 ct;

    void Awake()
    {
        ct = ConnectionToolV2.getInstance();
        //if (r == null)
        //{
        //    r = (Renderer)gameObject.GetComponent<Renderer>();
        //    setIsUse(false);
        //}
    }

    public void buttonPressed()
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
    public void buttonReleased()
    {
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
        //if (b)
        //{
        //    r.material.SetColor("_Color", Color.green);
        //}
        //else {
        //    switch (buttonType)
        //    {
        //        case ButtonType.OUTPUT_DATA:
        //            r.material.SetColor("_Color", Color.red);
        //            break;
        //        case ButtonType.OUTPUT_SEQUENCE:
        //            r.material.SetColor("_Color", Color.white);
        //            break;
        //    }
        //}
        this.inUse = b;
    }
}
