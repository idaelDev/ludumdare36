using UnityEngine;
using System.Collections;

/// <summary>
/// Map Cell contain data specified on the map and manage accessibility of what is inside it
/// </summary>
public class Cell {

    private static Cell[] directions = 
	{
		new Cell (0, 1), new Cell (1, 1), new Cell (1, 0), new Cell (1, -1),
		new Cell (0, -1), new Cell (-1, -1), new Cell (-1, 0), new Cell (-1, 1)
	};

    private static float[] rotations =
    {
        0.0f, 45.0f, 90.0f, 135.0f,
        180.0f, 225.0f, 270, 315.0f
    };

    public Vector2 Coordinates { get; private set; }

	private CellType type;

	public CellType Type {
		get {
			return type;
		}
		set{
			type = value;
		}
	}
	

    public Cell()
    {
        Coordinates = Vector2.zero;
        type = CellType.SEA;
    }

    public Cell(int p_x, int p_y)
    {
        Coordinates = new Vector2(p_x, p_y); 
        type = CellType.SEA;
    }

    private Cell(Vector2 p_coordinates)
    {
        Coordinates = p_coordinates;
    }

    public bool Walkable
    {
        get
        {
            return type == CellType.SEA;
        }
    }

    public int GetRelativeDirectionFrom(Cell c)
    {
        float angle = Vector2.Angle(directions[0].Coordinates, c.Coordinates);
        Debug.Log("ANGLE : " + angle);
        float halfAngle = 45.0f / 2.0f;
        for (int i = 0; i < rotations.Length; i++)
        {
            if(angle > rotations[i] - halfAngle && angle <= rotations[i] + halfAngle)
            {
                return i;
            }
        }
        return 0;
    }

    public static float Distance(Cell c1, Cell c2)
    {
        return Vector2.Distance(c1.Coordinates, c2.Coordinates);
    }

	public static Cell GetNeighbor(Cell c, Directions direction)
	{
		return GetNeighbor (c, (int)direction);
	}
	
	public static Cell GetNeighbor(Cell c, int direction)
	{
		return c + directions [direction];
	}

    public static Cell GetDirection(int direction)
    {
        return directions[(int)direction];
    }

    public static float GetRotationAngle(int direction)
    {
        return rotations[(int)direction];
    }

    #region Operator override
    public static bool operator == (Cell c1, Cell c2)
    {
        // If both are null, or both are same instance, return true.
        if (System.Object.ReferenceEquals(c1, c2))
        {
            return true;
        }

        // If one is null, but not both, return false.
        if (((object)c1 == null) || ((object)c2 == null))
        {
            return false;
        }

        return c1.Coordinates == c2.Coordinates;
    }

    public static bool operator !=(Cell c1, Cell c2)
    {

        return !(c1 == c2);
    }

	public static Cell operator +(Cell c1, Cell c2)
	{
		return new Cell(c1.Coordinates + c2.Coordinates);
	}

	public static Cell operator -(Cell c1, Cell c2)
	{
		return new Cell(c1.Coordinates - c2.Coordinates);
	}

    public override bool Equals(object obj)
    {
        // If parameter is null return false:
        if ((object)obj == null)
        {
            return false;
        }

        // Return true if the fields match:
        return this == (Cell)obj;
    }

    public override int GetHashCode()
    {
        return Coordinates.GetHashCode();
    }
    #endregion
}

public enum CellType
{
    SEA = 0,
    LAND = 1
}

public enum Directions
{
	NORTH = 0,
	NORTH_EAST = 1,
	EAST = 2,
	SOUTH_EAST = 3,
	SOUTH = 4,
	SOUTH_WEST = 5,
	WEST = 6,
	NORTH_WEST = 7
}