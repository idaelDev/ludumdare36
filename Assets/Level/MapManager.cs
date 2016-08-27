using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

    Map map;

    // Use this for initialization
    void Start()
    {
        map = new Map(10);
    }

    void Update()
    {
        if(Input.GetKeyDown (KeyCode.B))
        {
            map.mapGeneration();
            foreach (Vector2 item in map.cellContainer.Keys)
            {
                Debug.Log(item);
            }
        }
    }

}
