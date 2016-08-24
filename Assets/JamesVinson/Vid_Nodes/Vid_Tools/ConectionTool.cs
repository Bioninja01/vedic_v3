using UnityEngine;
using System.Collections;
using System;

public class ConectionTool
{
    private static ConectionTool instance;
    private InputButton inputButton;
    private OutputButton outputButton;

    private ConectionTool()
    {
    }

    public static ConectionTool getInstance()
    {
        if (instance == null)
        {
            instance = new ConectionTool();
        }
        return instance;
    }

    public bool currentSeleted()
    {
        return outputButton != null;
    }

    public InputButton getInputButton()
    {
        return inputButton;
    }
    public OutputButton getOutputButton()
    {
        return outputButton;
    }

    public void setOutputButton(OutputButton n)
    {
        outputButton = n;
    }
    public void setInputButton(InputButton c)
    {
        inputButton = c;
    }

    public void resetTool()
    {
        inputButton = null;
        outputButton = null;
    }
}

