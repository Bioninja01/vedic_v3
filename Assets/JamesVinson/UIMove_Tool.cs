using UnityEngine;
using UnityEngine.UI;
using Leap.Unity;

public class UIMove_Tool : MonoBehaviour {
    GameObject holding;
    public JamesV_LeapRTS rts;

    void Awake()
    {
        if(rts != null)
        {
            rts.enabled = false;
        }
        else
        {
            rts = gameObject.AddComponent<JamesV_LeapRTS>();
            rts.speed = 5;
            rts.enabled = false;
            /*Todd: finish setting up rts*/
        }
    }

    public void setholding(GameObject obj2hold)
    {
        if (holding == null)
        {
            setNewHolder(obj2hold);
        }
        else
        {
            deActivateHolder();
            if (obj2hold != holding)
            {
                setNewHolder(obj2hold);
                return;
            }
            else
            {
                holding = null;
            }
        }
    }

    private void setNewHolder(GameObject obj2hold)
    {
        Vid_ObjContainer com;
        rts.enabled = true;
        rts.transform.position = obj2hold.transform.position;
        rts.transform.rotation = obj2hold.transform.rotation;
        holding = obj2hold;
        holding.transform.SetParent(this.transform);
        com = holding.GetComponent<Vid_ObjContainer>();
        if (com == null) { return; }

        Text t = com.getText();
        t.text = "Active";
        Image i = com.selectButton_background;
        if (i != null)
        {
            i.color = Color.green;
        }
    }

    private void deActivateHolder()
    {
        Vid_ObjContainer com;
        rts.enabled = false;
        holding.transform.parent = null;
        com = holding.GetComponent<Vid_ObjContainer>();
        if (com == null)
        {
            holding = null;
            return;
        }
        Text t = com.getText();
        t.text = "Select";
        Image i = com.selectButton_background;
        if (i != null)
        {
            i.color = Color.white;
        }
    }
}
