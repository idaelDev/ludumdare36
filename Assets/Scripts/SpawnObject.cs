using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

    public GameObject objectToSpawn;
    public bool isSpawned = false;

    public void Spawn()
    {
        if (!isSpawned)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.enabled = false;

            SpriteRenderer[] srt = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer item in srt)
            {
                item.enabled = false;
            }

            GameObject obj = Instantiate(objectToSpawn, transform.position, transform.rotation) as GameObject;
            obj.transform.SetParent(this.transform);
            isSpawned = true;
        }

    }

    
}
