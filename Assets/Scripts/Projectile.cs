using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{

	public float velocity = 20.0F;
	public Vector2 direction = Vector2.up;
	public int damage = 5;
	public int decorDamage = 10;

	public GameObject shooter;

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

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag != this.shooter.tag) 
		{
			SimplePool.Despawn (this.gameObject);
		}

		if (coll.gameObject.tag == "ennemy" || coll.gameObject.tag == "Player") 
		{
			Damageable damageable = coll.gameObject.GetComponent<Damageable>();

			if (this.shooter.tag != coll.gameObject.tag) 
			{
				damageable.Damage(damage);
			}
		}

		if (coll.gameObject.tag == "decor")
		{
			Damageable damageable = coll.gameObject.GetComponent<Damageable> ();
			damageable.Damage(decorDamage);
		}
	}
}
