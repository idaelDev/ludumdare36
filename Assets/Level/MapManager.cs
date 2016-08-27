using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

    public int roomNumber = 10;

    private Map map;
    private GameObject[] rooms;
    private Vector2 currentCoord;
    private Room currentRoom;
    Hashtable roomTable;

    // Use this for initialization
    void Start()
    {
        map = new Map(roomNumber);
        roomTable = new Hashtable(roomNumber);
        rooms = Resources.LoadAll<GameObject>("levels");
        Initmap();
        currentCoord = Vector2.zero;
        GameObject o = roomTable[currentCoord] as GameObject;
        currentRoom = o.GetComponent<Room>();
        InitCurrentRoom();
    }

    private void InitCurrentRoom()
    {
        currentRoom.gameObject.SetActive(true);
        currentRoom.playerOutEvent += SetCurrentRoom;
        bool[] walls = { true, true, true, true};
        for (int i = 0; i < 4; i++)
        {
            if (roomTable.ContainsKey(Cell.GetNeighbor(map.cellContainer[currentCoord] as Cell, i).Coordinates))
            {
                walls[i] = false;
            }
        }
        currentRoom.SetWalls(walls[0], walls[1], walls[2], walls[3]);
    }

    private void SetCurrentRoom(Directions dir)
    {
        currentRoom.playerOutEvent -= SetCurrentRoom;
        Cell c = Cell.GetNeighbor(map.cellContainer[currentCoord] as Cell, dir);
        currentCoord = c.Coordinates;
        GameObject o = roomTable[currentCoord] as GameObject;
        currentRoom = o.GetComponent<Room>();

        Vector2 worldPosition = new Vector2(currentCoord.x * 18, currentCoord.y * 10);
        CameraController.Instance.SetPosition(worldPosition);

        InitCurrentRoom();
    }

    private void Initmap()
    {
        map.mapGeneration();
        Debug.Log("Map Generated");
        foreach(Cell item in map.cellContainer.Values)
        {
            Vector2 pos = new Vector2(item.Coordinates.x * 18, item.Coordinates.y * 10);
            GameObject drawable = rooms[(int)(Random.Range(0, rooms.Length - 0.01f))];
            GameObject roomInstance = Instantiate(drawable, pos, Quaternion.identity)as GameObject;
            roomInstance.SetActive(false);
            roomTable.Add(item.Coordinates, roomInstance);
        }
    }

}
