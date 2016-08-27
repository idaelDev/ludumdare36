using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map{

    private int roomNb;

    public Hashtable cellContainer { get; private set; }

    public Map()
    {
        roomNb = 10 ;
    }

	public Map(int p_roomNb)
    {
        roomNb = p_roomNb;
    }

    //public void mapGeneration()
    //{
        //cellContainer = new Hashtable(sizeX * sizeY);
        //for (int x = 0; x < sizeX; x++)
        //{
        //    for (int y = 0; y < sizeY; y++)
        //    {
        //        Cell c = new Cell(x, y);
        //        cellContainer.Add(c.Coordinates, c);
        //    }
        //}
        //Debug.Log(cellContainer.Count);
   // }

	private void mapGeneration(int p_roomNb)
	{
        roomNb = p_roomNb;
		mapGeneration();
	}

    public void mapGeneration()
    {
        int currentNbRoom = 0;
        cellContainer = new Hashtable(roomNb);
        List<Vector2> keyList = new List<Vector2>(roomNb);

        Cell c = new Cell(0,0);
        cellContainer.Add(c.Coordinates, c);
        keyList.Add(c.Coordinates);
        currentNbRoom++;

        Cell n = Cell.GetNeighbor(c,(int)( Random.Range(0f,3.99f)));
        cellContainer.Add(n.Coordinates, n);
        keyList.Add(n.Coordinates);
        currentNbRoom++;

        while(currentNbRoom < roomNb)
        {
            Vector2 currentPos = keyList[(int)(Random.Range(0, keyList.Count - 0.01f))]; //select random Room
            Cell currentCell = cellContainer[currentPos] as Cell;
            //Check enigbors
            bool isOpen = false;
            bool[] openRooms = { false, false, false, false };
            for (int i = 0; i < 4; i++)
            {
                if (!cellContainer.ContainsKey(Cell.GetNeighbor(currentCell, i).Coordinates))
                {
                    openRooms[i] = true;
                    isOpen = true;
                }
            }

            if (isOpen)
            {
                int dir = 0;
                do
                {
                    dir = (int)(Random.Range(0f, 3.99f));
                }
                while (!openRooms[dir]);
                Cell newCell = Cell.GetNeighbor(currentCell, dir);
                cellContainer.Add(newCell.Coordinates, newCell);
                keyList.Add(newCell.Coordinates);
                currentNbRoom++;
            }
        }
    }

    public Cell GetCell(int x, int y)
    {
        return GetCell(new Vector2(x, y));
    }

    public Cell GetCell(Vector2 coordinates)
    {
        if(cellContainer.ContainsKey(coordinates))
        {
            return ((Cell)cellContainer[coordinates]);
        }
        return null;
    }
}

//public void SetMapSize(int newX, int newY)
//{
//	if(newX > sizeX)
//	{
//		for (int x = sizeX; x < newX; x++)
//		{
//			for (int y = 0; y < sizeY; y++)
//			{
//				Cell c = new Cell(x, y);
//				cellContainer.Add(c.Coordinates, c);
//			}
//		}
//	}
//	else if(newX < sizeX)
//	{
//		for (int x = newX; x < sizeX; x++)
//		{
//			for (int y = 0; y < sizeY; y++)
//			{
//				Cell c = new Cell(x, y);
//				cellContainer.Remove (c.Coordinates);
//			}
//		}
//	}
//	sizeX = newX;

//	if(newY > sizeY)
//	{
//		for (int x = 0; x < sizeX; x++)
//		{
//			for (int y = sizeY; y < newY; y++)
//			{
//				Cell c = new Cell(x, y);
//				cellContainer.Add(c.Coordinates, c);
//			}
//		}
//	}
//	else if(newY < sizeY)
//	{
//		for (int x = 0; x < sizeX; x++)
//		{
//			for (int y = newY; y < sizeY; y++)
//			{
//				Cell c = new Cell(x, y);
//				cellContainer.Remove (c.Coordinates);
//			}
//		}
//	}
//	sizeY = newY;
//}