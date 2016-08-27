using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour 
{
	public int maxLife, actualLife;

    public delegate void CharaDead();
    public event CharaDead deadEvent;

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
            Dead();
		}
	}

    public void Dead()
    {
        if (deadEvent != null)
        {
            deadEvent();
        }

        gameObject.SetActive(false);
    }

	public void Damage(int damageCount)
	{
		actualLife -= damageCount;
	}
}
