using UnityEngine;
using System.Collections;

public class TurretGun : MonoBehaviour 
{
	public GameObject projectile;

	private Vector2[] directions = new Vector2[4] {Vector2.up, Vector2.right, Vector2.down, Vector2.left};
	private int index = 0;

	public float fireEvery = 1.0F;
	private float timer = 0.0F;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if (timer >= this.fireEvery) 
		{
			timer = 0.0F;

			GameObject projectileInstance = SimplePool.Spawn (projectile, transform.position, Quaternion.identity) as GameObject;
			Projectile projectileSettings = projectileInstance.GetComponent<Projectile> ();
			projectileSettings.shooter = this.gameObject;

			if (index >= directions.Length) {
				index = 0;
			}

			projectileSettings.direction = directions [index];
			index++;
		}
	}
}
