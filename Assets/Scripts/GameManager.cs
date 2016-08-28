using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    public int maxHealth = 100;
    public int health;
    public int maxExp = 100;
    public int exp;

    public delegate void PlayerDead();
    public event PlayerDead playerDeadEvent;

    public delegate void LevelUp();
    public event LevelUp levelUpEvent;

    public int roomNumber = 10;
    public int roomToClear;
    public int level;

    private bool levelstarted = true;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}

    void Update()
    {
        if(!levelstarted && SceneManager.GetSceneByName("Main").isLoaded)
        {
            StartLevel();
        }
    }

    public void StartLevel()
    {
        health = maxHealth;
        exp = maxExp;
        roomToClear = roomNumber;
        MapManager.Instance.Init(roomNumber);
        levelstarted = true;
    }

    public void RoomCleared()
    {
        roomToClear--;
        if (roomToClear <= 0)
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        levelstarted = false;
        SceneManager.LoadScene("Main",LoadSceneMode.Single);
        
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
