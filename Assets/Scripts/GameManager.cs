using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    public int maxHealth = 100;
    public int health;
    public int maxExp = 100;
    public int exp;

    public delegate void PlayerDead();
    public event PlayerDead playerDeadEvent;

    public delegate void LevelUp();
    public event LevelUp levelUpEvent;

	// Use this for initialization
	void Start () {
        health = maxHealth;
        exp = maxExp;
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            health = 0;
            if(playerDeadEvent != null)
            {
                playerDeadEvent();
            }
        }
    }

    public void TakeExp(int xp)
    {
        exp += xp;
        if(exp >= maxExp)
        {
            
            exp = 0;
            if(levelUpEvent != null)
            {
                levelUpEvent();
            }
        }
    }


}
