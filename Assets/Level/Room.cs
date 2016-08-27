using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

    public BoxCollider2D RightWall;
    public BoxCollider2D LeftWall;
    public BoxCollider2D UpWall;
    public BoxCollider2D DownWall;

    public GameObject enemiesContainer;

    public delegate void PlayerOut(Directions dir);
    public event PlayerOut playerOutEvent;

    public bool cleared = false;
    public bool frontierDone = false;
    bool[] walls = { false, false, false, false };

    public int nbEnnemies = 0;

	// Use this for initialization
	void Start () {
        Damageable[] enemies = enemiesContainer.GetComponentsInChildren<Damageable>();
        nbEnnemies = enemies.Length ;
        if(nbEnnemies == 0)
        {
            cleared = true;
            EndRoom();
        }
        else
        {
            foreach (Damageable item in enemies)
            {
                item.deadEvent += UpdateEnemies;
            }
        }
	}
	
    public void InitRoom()
    {
        SetWalls(true, true, true, true);
        if(cleared)
        {
            EndRoom();
        }
    }

    public void EndRoom()
    {
        SetWalls(walls[0], walls[1], walls[2], walls[3]);
    }

    private void UpdateEnemies()
    {
        nbEnnemies--;
        if(nbEnnemies <= 0)
        {
            cleared = true;
            EndRoom();
            Debug.Log("Room Cleared");
        }
    }


    public void SetWalls(bool up, bool right, bool down, bool left)
    {
        if(!frontierDone)
        {
            walls[0] = up;
            walls[1] = right;
            walls[2] = down;
            walls[3] = left;
            frontierDone = true;
        }

        UpWall.enabled = up;
        RightWall.enabled = right;
        DownWall.enabled = down;
        LeftWall.enabled = left;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Vector3 playerPos = other.transform.position;
            Vector3 pos = transform.position;
            if (playerPos.x > pos.x + 9)
            {
                if (playerOutEvent != null)
                {
                    playerOutEvent(Directions.EAST);
                }
            }
            else if (playerPos.y < pos.y - 5)
            {
                if (playerOutEvent != null)
                {
                    playerOutEvent(Directions.SOUTH);
                }
            }
            else if(playerPos.x < pos.x -9)
            {
                if (playerOutEvent != null)
                {
                    playerOutEvent(Directions.WEST);
                }
            }
            else if(playerPos.y > pos.y + 5)
            {
                if (playerOutEvent != null)
                {
                    playerOutEvent(Directions.NORTH);
                }
            }
            //this.gameObject.SetActive(false);
        }
    }
}
