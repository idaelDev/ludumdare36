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

    public int nbEnnemies = 0;

	// Use this for initialization
	void Start () {
        Damageable[] enemies = enemiesContainer.GetComponentsInChildren<Damageable>();
        nbEnnemies = enemies.Length ;
        if(nbEnnemies == 0)
        {
            cleared = true;
        }
        else
        {
            foreach (Damageable item in enemies)
            {
                item.deadEvent += UpdateEnemies;
            }
        }
	}
	
    private void UpdateEnemies()
    {
        nbEnnemies--;
        if(nbEnnemies <= 0)
        {
            cleared = true;
            Debug.Log("Room Cleared");
        }
    }


    public void SetWalls(bool up, bool right, bool down, bool left)
    {
        RightWall.enabled = right;
        LeftWall.enabled = left;
        UpWall.enabled = up;
        DownWall.enabled = down;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Vector3 playerPos = other.transform.position;
            Vector3 pos = transform.position;
            if (playerPos.x > pos.x + 9)
            {
                playerOutEvent(Directions.EAST);
            }
            else if (playerPos.y < pos.y - 5)
            {
                playerOutEvent(Directions.SOUTH);
            }
            else if(playerPos.x < pos.x -9)
            {
                playerOutEvent(Directions.WEST);
            }
            else if(playerPos.y > pos.y + 5)
            {
                playerOutEvent(Directions.NORTH);
            }
            //this.gameObject.SetActive(false);
        }
    }
}
