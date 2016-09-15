using UnityEngine;
using System.Collections;
using LMWidgets;

public class InputButton : NodeButton {

    public int argumentIndex;

    public Vid_Object vidObj;

    bool used = false;
    public bool drawline = false;
    public OutputButton output;
    public LineRenderer lineRender;
    Renderer r;

    public override void buttonPressed()
    {
        Debug.Log("Test:1");
        if (used && ct.getOutputButton() == null)
        {
            lineRender.enabled = false;
            drawline = false;

            vidObj.removeInput(argumentIndex);

            output = null;
            used = false;
        }
        else {
            Debug.Log("Test:2");
            if ((ct.getInputButton() == null) && (ct.getOutputButton() != null))
            {
                Debug.Log("Test:3");
                transferData();
            }
        }
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
        VidData_Type[] acceptable_dataTypes = vidObj.getAcceptableInputs();
        output = ct.getOutputButton();
        Vid_Object outputObj = output.vid_obj;
        Debug.Log("Test:4");
        foreach (VidData_Type d in acceptable_dataTypes)
        {
            Debug.Log(d == outputObj.output_dataType);
            if (d == outputObj.output_dataType)
            {
                ct.setInputButton(this);
                output.setIsUse(false);
                Debug.Log("argumentIndex : " + argumentIndex);
                bool b = vidObj.addInput(outputObj, argumentIndex);
                Debug.Log(b +"here");
                if (b) {
                    used = true;
                    drawline = true;
                }
                ct.resetTool();
                break;
            }
        }
    }
}
