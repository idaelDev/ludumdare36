using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour 
{
	public int maxLife, actualLife;

	// Use this for initialization
	void Start () 
	{ }
	
	// Update is called once per frame
	void Update () 
	{
		if (actualLife > maxLife) 
		{
			actualLife = maxLife;
		}

		if (actualLife <= 0) 
		{
			Destroy(this.gameObject);
		}
	}

	void Damage(int damageCount)
	{
		actualLife -= damageCount;
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "bullet") 
		{
			Projectile projectile = coll.gameObject.GetComponent<Projectile>();

			if (projectile.shooter.tag != this.gameObject.tag) 
			{
				this.Damage(projectile.damage);
			}
		}
	}
}
