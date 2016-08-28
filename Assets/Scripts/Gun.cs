﻿using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour 
{

	public GameObject projectile;
	public GameObject directionIndicator;

	public float fireEvery = 0.1F;
	private float timer = 0.0F;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.timer += Time.deltaTime;

		float verticalFireAxis = Input.GetAxisRaw("Fire1");
		float horizontalFireAxis = Input.GetAxisRaw("Fire2");

		if ((verticalFireAxis != 0 || horizontalFireAxis != 0) && this.timer >= this.fireEvery) 
		{
			this.timer = 0.0F;

			GameObject projectileInstance = SimplePool.Spawn(projectile, transform.position, Quaternion.identity) as GameObject;
			Projectile projectileSettings = projectileInstance.GetComponent<Projectile> ();
            projectileInstance.layer = LayerMask.NameToLayer("PlayerShot");
			projectileSettings.shooter = this.gameObject;

			// I'm not certain of the quality of this whole thing…
			if (verticalFireAxis == 1.0F) {
				projectileSettings.direction = Vector2.up;
				directionIndicator.transform.localEulerAngles = new Vector3 (0, 0, 180);
			} else if (verticalFireAxis == -1.0F) {
				projectileSettings.direction = Vector2.down;
				directionIndicator.transform.localEulerAngles = new Vector3 (0, 0, 360);
			}

			if (horizontalFireAxis == 1.0F) {
				projectileSettings.direction = Vector2.right;
				directionIndicator.transform.localEulerAngles = new Vector3 (0, 0, 90);
			} else if (horizontalFireAxis == -1.0F) {
				projectileSettings.direction = Vector2.left;
				directionIndicator.transform.localEulerAngles = new Vector3 (0, 0, -90);
			}
		}
	}
}
