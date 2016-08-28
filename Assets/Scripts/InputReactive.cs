using UnityEngine;
using System.Collections;

public class InputReactive : MonoBehaviour 
{
	public float movementSpeed = 10.0F;

	public GameObject hoverBoard;

	private new Transform transform;

	// Use this for initialization
	void Start () 
	{
		transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float horizontalTranslation = Input.GetAxis ("Horizontal") * movementSpeed;
		float verticalTranslation = Input.GetAxis("Vertical") * movementSpeed;

        horizontalTranslation *= Time.deltaTime;
		verticalTranslation *= Time.deltaTime;

		transform.Translate(horizontalTranslation, verticalTranslation, 0);
	}
}
