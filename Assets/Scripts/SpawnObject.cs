using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

    public GameObject objectToSpawn;
    public bool isSpawned = false;

    public void Spawn()
    {
        if (!isSpawned)
        {
            GameObject obj = Instantiate(objectToSpawn, transform.position, transform.rotation) as GameObject;
            obj.transform.SetParent(this.transform);
            isSpawned = true;
        }
    }
}
