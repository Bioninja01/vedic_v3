using UnityEngine;
using System.Collections.Generic;

public abstract class NodeButton : MonoBehaviour {

    public ConnectionTool ct;
    List<Vid_Action> actions;

    public NodeButton() {
        actions = new List<Vid_Action>();
    }
    public virtual void Awake() {
        ct = ConnectionTool.getInstance();
    }

    public abstract void buttonPressed();
    public virtual void buttonReleased() { }

    public void addAction(Vid_Action a) {
        actions.Add(a);
    }
    public void removeAction(Vid_Action a) {
        actions.Remove(a);
    }
    public void getAction(int index) {
        if(actions.Count > index 
                         && index > -1) {

        }
    }

    

}
