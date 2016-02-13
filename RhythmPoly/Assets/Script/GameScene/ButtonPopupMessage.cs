using UnityEngine;

/// <summary>
/// Sends a message to the remote object when something happens.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Button Message (Legacy)")]
public class ButtonPopupMessage : MonoBehaviour {

    public enum Trigger
    {
        OnClick,
        OnMouseOver,
        OnMouseOut,
        OnPress,
        OnRelease,
        OnDoubleClick,
    }

    public GameObject target;
    //    public GameObject player;
    //    public GameObject scrollview;
    public string functionName;
    public Trigger trigger = Trigger.OnClick;
    public bool includeChildren = false;

    bool mStarted = false;


    // 눌려있는지 확인
//    bool press = false;

    void Start() { mStarted = true; }
    void Update()
    {
        /*
        if (press)
        {
            if (trigger == Trigger.OnPress)
                Send();
        }
         */
    }

    
    void OnEnable() { if (mStarted) OnHover(UICamera.IsHighlighted(gameObject)); }

    void OnHover(bool isOver)
    {
        if (enabled)
        {
            if (((isOver && trigger == Trigger.OnMouseOver) ||
                (!isOver && trigger == Trigger.OnMouseOut))) Send();
        }
    }

    void OnPress(bool isPressed)
    {
        if (enabled)
        {
            if (((isPressed && trigger == Trigger.OnPress) ||
                (!isPressed && trigger == Trigger.OnRelease)))
            {
                Send();
            }
        }
    }

    void OnSelect(bool isSelected)
    {
        if (enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
            OnHover(isSelected);
    }

    void OnClick()
    {
        //        if (scrollview != null)
        //        {
        //            scrollview.SetActive(false);
        //            target.SetActive(true);
        //        }
        if (enabled && trigger == Trigger.OnClick) Send();
    }

    void OnDoubleClick() { if (enabled && trigger == Trigger.OnDoubleClick) Send(); }

    void Send()
    {
        if (string.IsNullOrEmpty(functionName)) return;
        if (target == null) target = gameObject;

        if (includeChildren)
        {
            Transform[] transforms = target.GetComponentsInChildren<Transform>();

            for (int i = 0, imax = transforms.Length; i < imax; ++i)
            {
                Transform t = transforms[i];
                t.gameObject.SendMessage(functionName, gameObject, SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            target.SendMessage(functionName, gameObject, SendMessageOptions.DontRequireReceiver);
        }
    }
}
