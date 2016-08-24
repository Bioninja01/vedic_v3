using UnityEngine;
using System.Collections;

public class Input_NumButton : InputButton {

    Input_NumButton() {
        base.input_dataType = VidData_Type.NUM;
    }

    protected override void buttonPressed() {
        base.buttonPressed();
//        if(output_vidObj != null) {
//            vidObj.addInput( output_vidObj.getOutput(),ArgumentIndex);
//        }
    }
}
