using UnityEngine;
using System.Collections.Generic;
using LMWidgets;

public class MultiInputButton : InputButton {

    public List<LineRenderer> lines;
    public List<OutputButton> outputs;
    
    public override void buttonPressed() {
        if ( ct.getOutputButton() == null) {
            lineRender.enabled = false;
            drawline = false;
            switch (buttonType) {
                case ButtonType.INPUT_DATA:
                    vidObj.removeInput(argumentIndex);
                    vidObj.updateData();
                    break;
                case ButtonType.INPUT_SEQUENCE:
                    output.removeSequence();
                    break;
            }
            output = null;

        }
        else {
            if ((ct.getInputButton() == null) && (ct.getOutputButton() != null)) {
                switch (buttonType) {
                    case ButtonType.INPUT_DATA:
                        //transferData();
                        break;
                    case ButtonType.INPUT_SEQUENCE:
                        //transferSequence();
                        break;
                }
            }
        }
    }

    private void transferData() {
        VidData_Type[] acceptable_dataTypes = vidObj.getAcceptableInputs();
        output = ct.getOutputButton();
        Vid_Object outputObj = output.vid_obj;
        foreach (VidData_Type d in acceptable_dataTypes) {
            if (d == outputObj.output_dataType) {
                ct.setInputButton(this);
                output.setIsUse(false);

                vidObj.addInput(outputObj, argumentIndex);
                vidObj.updateData();

                drawline = true;
                ct.resetTool();
                break;
            }
        }
    }
    private void transferSequence() {
        output = ct.getOutputButton();
        ct.setInputButton(this);
        output.setIsUse(false);

        Vid_SequenceableObject seqObj = (Vid_SequenceableObject)vidObj;
        Debug.Log(seqObj.ToString());

        output.addSequence(seqObj);

        drawline = true;
        ct.resetTool();
    }

}
