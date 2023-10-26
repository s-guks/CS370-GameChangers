using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSlot
{
    // Properties to store information about the slot
    public bool IsOccupied { get; set; }
    public GamePiece OccupyingPiece { get; set; }

    // Constructor
    public TableSlot()
    {
        IsOccupied = false;
        OccupyingPiece = null;
    }

    // Method to place a game piece into the slot
    public void PlacePiece(GamePiece piece)
    {
        IsOccupied = true;
        OccupyingPiece = piece;
    }

    // Method to remove the game piece from the slot
    public void RemovePiece()
    {
        IsOccupied = false;
        OccupyingPiece = null;
    }
}

public class GamePiece
{
    // Properties to store information about the game piece
    public string Name { get; set; }

    // Constructor
    public GamePiece(string name)
    {
        Name = name;
    }
}