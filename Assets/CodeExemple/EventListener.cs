using UnityEngine;
using System.Collections;

public class EventListener : MonoBehaviour {

    EventSender sender;

	// Use this for initialization
	void Start () {
        sender = GetComponent<EventSender>();
        sender.inputEvent += EventTrigger;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void EventTrigger()
    {
        Debug.Log("Hey");
    }
}
