using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

    private Map map;
    private GameObject[] rooms;

    // Use this for initialization
    void Start()
    {
        map = new Map(10);
        rooms = Resources.LoadAll<GameObject>("levels");
        Initmap();
    }

    void Update()
    {
    }

    private void Initmap()
    {
        map.mapGeneration();
        Debug.Log("Map Generated");
        foreach(Cell item in map.cellContainer.Values)
        {
            Vector2 pos = new Vector2(item.Coordinates.x * 18, item.Coordinates.y * 10);
            GameObject drawable = rooms[(int)(Random.Range(0, rooms.Length - 0.01f))];
            Instantiate(drawable, pos, Quaternion.identity);
        }
    }

}
