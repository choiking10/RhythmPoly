using UnityEngine;
using System.Collections;

public class TouchReceiver : MonoBehaviour
{
    public UILabel la;

    // Add Point
    public void TouchAttachPoint()
    {
        Debug.Log("touch Attach");
        la.text = "touch Attach";
    }
    // Sub Point
    public void TouchDetachPoint()
    {
        Debug.Log("touch Detach");
        la.text = "touch Detach";
    }

    public void DoubleTouchPoint()
    {
        Debug.Log("Double Touch");
        la.text = "Double Touch";
    }
    public void TouchPause()
    {
        Debug.Log("touch Pause");
        la.text = "touch Pause";
    }
}
