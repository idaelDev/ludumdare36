using UnityEngine;
using System.Collections;

public class Map{

    private int sizeX;
    private int sizeY;

    public Hashtable cellContainer { get; private set; }

    public Map()
    {
        sizeX = 20;
        sizeY = 20;
    }

	public Map(int p_sizeX, int p_sizeY)
    {
        sizeX = p_sizeX;
        sizeY = p_sizeY;
    }

    public void mapGeneration()
    {
        cellContainer = new Hashtable(sizeX * sizeY);
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                Cell c = new Cell(x, y);
                cellContainer.Add(c.Coordinates, c);
            }
        }
        Debug.Log(cellContainer.Count);
    }

	private void mapGeneration(int p_sizeX, int p_sizeY)
	{
		sizeX = p_sizeX;
		sizeY = p_sizeY;
		mapGeneration();
	}

	public void SetMapSize(int newX, int newY)
	{
		if(newX > sizeX)
		{
			for (int x = sizeX; x < newX; x++)
			{
				for (int y = 0; y < sizeY; y++)
				{
					Cell c = new Cell(x, y);
					cellContainer.Add(c.Coordinates, c);
				}
			}
		}
		else if(newX < sizeX)
		{
			for (int x = newX; x < sizeX; x++)
			{
				for (int y = 0; y < sizeY; y++)
				{
					Cell c = new Cell(x, y);
					cellContainer.Remove (c.Coordinates);
				}
			}
		}
		sizeX = newX;

		if(newY > sizeY)
		{
			for (int x = 0; x < sizeX; x++)
			{
				for (int y = sizeY; y < newY; y++)
				{
					Cell c = new Cell(x, y);
					cellContainer.Add(c.Coordinates, c);
				}
			}
		}
		else if(newY < sizeY)
		{
			for (int x = 0; x < sizeX; x++)
			{
				for (int y = newY; y < sizeY; y++)
				{
					Cell c = new Cell(x, y);
					cellContainer.Remove (c.Coordinates);
				}
			}
		}
		sizeY = newY;
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
