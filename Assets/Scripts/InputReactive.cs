using UnityEngine;
using System.Collections;

public class InputReactive : MonoBehaviour 
{
	public float movementSpeed = 10.0F;

	public GameObject hoverBoard;
	public GameObject catBody;

	public Animator headAnimator;
	public Animator boardAnimator;

	private new Transform transform;

	// Use this for initialization
	void Start () 
	{
		transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float horizontalTranslation = Input.GetAxis ("Horizontal");
		float verticalTranslation = Input.GetAxis("Vertical");

		if (horizontalTranslation != 0.0F || verticalTranslation != 0.0F) 
		{
			headAnimator.SetBool ("Moving", true);
			boardAnimator.SetBool ("Moving", true);
		} 
		else 
		{
			headAnimator.SetBool ("Moving", false);
			boardAnimator.SetBool ("Moving", false);
		}

		if (horizontalTranslation > 0.0F) {
			hoverBoard.transform.localEulerAngles = new Vector3 (0, 0, 90);
			catBody.transform.localEulerAngles = new Vector3 (0, 0, 90);
		} else if (horizontalTranslation < 0.0F) {
			hoverBoard.transform.localEulerAngles = new Vector3 (0, 0, -90);
			catBody.transform.localEulerAngles = new Vector3 (0, 0, -90);
		}
		if (verticalTranslation > 0.0F) {
			hoverBoard.transform.localEulerAngles = new Vector3 (0, 0, 180);
			catBody.transform.localEulerAngles = new Vector3 (0, 0, 180);
		} else if (verticalTranslation < 0.0F) {
			hoverBoard.transform.localEulerAngles = new Vector3 (0, 0, 360);
			catBody.transform.localEulerAngles = new Vector3 (0, 0, 360);
		}

		horizontalTranslation *= movementSpeed;
		verticalTranslation *= movementSpeed;

        horizontalTranslation *= Time.deltaTime;
		verticalTranslation *= Time.deltaTime;

		transform.Translate(horizontalTranslation, verticalTranslation, 0);
	}
}
