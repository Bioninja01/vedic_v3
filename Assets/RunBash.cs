using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;

public class RunBash : MonoBehaviour {

    public void ExecuteCommand(string command)
    {
      try {
         Process myProcess = new Process();
         myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
         myProcess.StartInfo.CreateNoWindow = true;
         myProcess.StartInfo.UseShellExecute = false;
         myProcess.StartInfo.FileName = "C:\\Windows\\system32\\cmd.exe";
         string path = "C:\\Users\\James\\Desktop\\bash scripts\\test.cmd";
         myProcess.StartInfo.Arguments = "/c" + path;
         myProcess.EnableRaisingEvents = true;
         myProcess.Start();
         myProcess.WaitForExit();
         int ExitCode = myProcess.ExitCode;
         //print(ExitCode);
         } catch (Exception e){
             print(e);        
         }
    }

}
