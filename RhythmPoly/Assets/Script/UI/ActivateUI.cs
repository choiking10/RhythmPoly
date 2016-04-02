using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ActivateUI : MonoBehaviour {

    public GameObject[] blind;

    public void DisabledAll()
    {
        foreach (GameObject b in blind)
        {
            if (b != null)
            {
                b.SetActive(false);
            }
        }
        foreach(EventTrigger ev in gameObject.GetComponentsInChildren<EventTrigger>()){
            ev.enabled = false;
        }
        
    }
    public void EnabledAll()
    {

        foreach (GameObject b in blind)
        {
            if (b != null)
            {
                b.SetActive(true);
            }
        }
        foreach (EventTrigger ev in gameObject.GetComponentsInChildren<EventTrigger>())
        {
            ev.enabled = true;
        }
    }
}
