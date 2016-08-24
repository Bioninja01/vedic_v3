using UnityEngine;
using System.Collections;

public class ConnectionToolV2  {

    private static ConnectionToolV2 instance;
    private InputButtonV2 inputButton;
    private OutputButtonV2 outputButton;

    private ConnectionToolV2()
    {
    }

    public static ConnectionToolV2 getInstance()
    {
        if (instance == null)
        {
            instance = new ConnectionToolV2();
        }
        return instance;
    }

    public bool currentSeleted()
    {
        return outputButton != null;
    }

    public InputButtonV2 getInputButton()
    {
        return inputButton;
    }
    public OutputButtonV2 getOutputButton()
    {
        return outputButton;
    }

    public void setOutputButton(OutputButtonV2 n)
    {
        outputButton = n;
    }
    public void setInputButton(InputButtonV2 c)
    {
        inputButton = c;
    }

    public void resetTool()
    {
        inputButton = null;
        outputButton = null;
    }
}
