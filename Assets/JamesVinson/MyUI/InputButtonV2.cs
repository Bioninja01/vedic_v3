using UnityEngine;
using System.Collections;
using LMWidgets;

public class InputButtonV2 : MonoBehaviour {

    public int argumentIndex;
    public VidData_Type input_dataType = VidData_Type.NUM;
    public ButtonType buttonType = ButtonType.INPUT_DATA;

    public Vid_Object vidObj;

    bool used = false;
    bool drawline = false;
    ConnectionToolV2 ct;
    OutputButtonV2 output;
    public LineRenderer lineRender;
    Renderer r;

   void Awake()
    {
        ct = ConnectionToolV2.getInstance();
        //if (r == null)
        //{
        //    r = (Renderer)gameObject.GetComponent<Renderer>();
        //    switch (buttonType)
        //    {
        //        case ButtonType.INPUT_DATA:
        //            r.material.SetColor("_Color", Color.blue);
        //            break;
        //        case ButtonType.INPUT_SEQUENCE:
        //            r.material.SetColor("_Color", Color.white);
        //            break;
        //    }
        //}
    }

    public void buttonPressed()
    {
        if (used && ct.getOutputButton() == null)
        {
            lineRender.enabled = false;
            drawline = false;
            switch (buttonType)
            {
                case ButtonType.INPUT_DATA:
                    vidObj.removeInput(argumentIndex);
                    vidObj.updateData();
                    break;
                case ButtonType.INPUT_SEQUENCE:
                    output.removeSequence();
                    break;
            }
            output = null;
            used = false;
        }
        else {
            if ((ct.getInputButton() == null) && (ct.getOutputButton() != null))
            {
                switch (buttonType)
                {
                    case ButtonType.INPUT_DATA:
                        transferData();
                        break;
                    case ButtonType.INPUT_SEQUENCE:
                        transferSequence();
                        break;
                }
            }
        }
    }

    public void buttonReleased()
    {
        
    }

   void Update()
    {
        if (drawline)
        {
            if (!lineRender.enabled)
            {
                lineRender.enabled = true;
            }
            Vector3[] points = new Vector3[2];
            points[0] = output.transform.position;
            points[1] = this.transform.position;
            lineRender.SetPositions(points);
        }
    }

    private void transferData()
    {
        VidData_Type[] output_dataType = vidObj.getAcceptableInputs();
        output = ct.getOutputButton();
        foreach (VidData_Type d in output_dataType)
        {
            if (d == output.vid_obj.getOutput().getVidData_type())
            {
                ct.setInputButton(this);
                output.setIsUse(false);

                Vid_Data data4Input = output.vid_obj.getOutput();
                vidObj.addInput(data4Input, argumentIndex);
                vidObj.updateData();

                used = true;
                drawline = true;
                ct.resetTool();
                break;
            }
        }
    }

    private void transferSequence()
    {
        output = ct.getOutputButton();
        ct.setInputButton(this);
        output.setIsUse(false);

        Vid_SequenceableObject seqObj = (Vid_SequenceableObject)vidObj;
        Debug.Log(seqObj.ToString());

        output.addSequence(seqObj);

        used = true;
        drawline = true;
        ct.resetTool();
    }



}
