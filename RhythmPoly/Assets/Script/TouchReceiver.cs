using UnityEngine;
using System.Collections;

public class TouchReceiver : MonoBehaviour {
    public int count = 0;
    public UILabel la;
    public int score = 0;

    // Add Point
    public void TouchAttachPoint()
    {
        count++;
        Debug.Log("touch Attach");
        DoubleTouchPoint();
    }
    // Sub Point
    public void TouchDetachPoint()
    {
        count++;
        Debug.Log("touch Detach");
        DoubleTouchPoint();
    }

    public void InitCount() 
    {
        count = 0;
    }
    public void DoubleTouchPoint() 
    {
        if (count == 2)
        {
            /* 변경사항 - 더블클릭했을 때 실행될 함수 추가 - Start */
            score += 1;
            la.text = score.ToString();
            /* 변경사항 - 더블클릭했을 때 실행될 함수 추가 - End */
            count = 0;
        }
    }
    public void TouchPause()
    {
        Debug.Log("touch Pause");
    }
}
