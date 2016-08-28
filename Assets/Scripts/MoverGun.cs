using UnityEngine;
using System.Collections;

public class MoverGun : MonoBehaviour 
{
	public GameObject projectile;

	private Vector2[] directions = new Vector2[8] {Vector2.up, new Vector2(1,1), Vector2.right,new Vector2(1, -1), Vector2.down, new Vector2(-1, -1), Vector2.left, new Vector2(-1, 1) };

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

            for (int i = 0; i < directions.Length; i++)
            {

                GameObject projectileInstance = SimplePool.Spawn(projectile, transform.position, Quaternion.identity) as GameObject;
                projectileInstance.layer = LayerMask.NameToLayer("ennemyShot");
                Projectile projectileSettings = projectileInstance.GetComponent<Projectile>();
                projectileSettings.shooter = this.gameObject;
                projectileSettings.direction = directions [i];
            }
		}
	}
}
