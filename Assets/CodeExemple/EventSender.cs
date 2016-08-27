using UnityEngine;
using System.Collections;

public class EventSender : MonoBehaviour 
{

    public delegate void InputDelegate();
    public event InputDelegate inputEvent;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	    if(Input.GetKeyDown(KeyCode.B))
        {
            inputEvent();
        }
	}
}
