using UnityEngine;
using System.Text;

public class Vid_BasicCondition : Vid_Object {

    public Condition_Type conditionType = Condition_Type.LESS;

    public new void Awake()
    {
        base.Awake();
        acceptableInputs = new VidData_Type[2];
            acceptableInputs[0] = VidData_Type.BOOL;
            acceptableInputs[1] = VidData_Type.NUM;
        vidObject_SetUP();
    }

    public override void updateData() {
        StringBuilder sb = new StringBuilder();
        if (inputs.getInput_atIndex(0) == null 
                || inputs.getInput_atIndex(1) == null) {
            sb.Append("null");
        }
        else {
            switch (conditionType) {
                case Condition_Type.LESS:
                    sb.Append("( " + inputs.getInput_atIndex(0).getData());
                    sb.Append(" <" + inputs.getInput_atIndex(1).getData() + " )");

                    break;
                case Condition_Type.LESS_EQU:
                    sb.Append("( " + inputs.getInput_atIndex(0).getData());
                    sb.Append(" <=" + inputs.getInput_atIndex(1).getData() + " )");
                    break;
                case Condition_Type.GREATER:
                    sb.Append("( " + inputs.getInput_atIndex(0).getData());
                    sb.Append(" >" + inputs.getInput_atIndex(1).getData() + " )");
                    break;
                case Condition_Type.GREATER_EQU:
                    sb.Append("( " + inputs.getInput_atIndex(0).getData());
                    sb.Append(" >=" + inputs.getInput_atIndex(1).getData() + " )");
                    break;
                case Condition_Type.EQU:
                    sb.Append("( " + inputs.getInput_atIndex(0).getData());
                    sb.Append(" ==" + inputs.getInput_atIndex(1).getData() + " )");
                    break;
                case Condition_Type.NOT_EQU:
                    sb.Append("( " + inputs.getInput_atIndex(0).getData());
                    sb.Append(" !=" + inputs.getInput_atIndex(1).getData() + " )");
                    break;
                default:
                    break;
            }
        }
        output.setData(sb.ToString());
    }

    public override bool addInput(Vid_Data data, int index)
    {
        if (data.getVidData_type() == VidData_Type.BOOL
                || data.getVidData_type() == VidData_Type.NUM)
        {
            base.addInput(data,index);
        }
        return false;
    }

    /*Helper functions*/
    private void vidObject_SetUP()
    {
        inputs = new Vid_ObjectInputs(2);
        output = new Vid_Data(VidData_Type.BOOL, this);
        output.setData("null");
    }

}
