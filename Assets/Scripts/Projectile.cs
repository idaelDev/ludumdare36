using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{

	public float velocity = 20.0F;
	public Vector2 direction = Vector2.up;

	private new Transform transform;

	// Use this for initialization
	void Start () 
	{
		transform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () 
	{
		Vector2 translation = direction * velocity;
		translation *= Time.deltaTime;

		transform.Translate(translation.x, translation.y, 0);
	}
}
