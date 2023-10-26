using System;
using System.Collections.Generic;

public class TableSlotMain
{
    static void Main()
    {
        // Create some game pieces
        GamePiece piece1 = new GamePiece("Piece 1");
        GamePiece piece2 = new GamePiece("Piece 2");
        GamePiece piece3 = new GamePiece("Piece 3");
        GamePiece piece4 = new GamePiece("Piece 4");
        GamePiece piece5 = new GamePiece("Piece 5");
        GamePiece piece6 = new GamePiece("Piece 6");

        // Create table slots
        TableSlot[] slots = new TableSlot[6];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new TableSlot();
        }

        // Create a list to keep track of occupied slots
        List<int> occupiedSlots = new List<int>();

        Console.WriteLine("Enter a number from 1 to 6 to place a card or any other key to exit.");

        while (true)
        {
            // Get user input
            string input = Console.ReadLine();

            if (int.TryParse(input, out int slotNumber) && slotNumber >= 1 && slotNumber <= 6)
            {
                if (!occupiedSlots.Contains(slotNumber))
                {
                    // Place the card into the slot
                    slots[slotNumber - 1].PlacePiece(GetGamePieceForSlotNumber(slotNumber));
                    occupiedSlots.Add(slotNumber);

                    Console.WriteLine($"Card placed in Slot {slotNumber}");
                    Console.WriteLine("Card Placed!");
                    return; // End the function after successful placement
                }
                else
                {
                    Console.WriteLine($"Slot {slotNumber} is already occupied. Please choose another slot.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
            }
        }
    }

    // Helper method to get a game piece based on the slot number
    static GamePiece GetGamePieceForSlotNumber(int slotNumber)
    {
        // Return the appropriate game piece based on the slot number
        switch (slotNumber)
        {
            case 1:
                return new GamePiece("Piece 1");
            case 2:
                return new GamePiece("Piece 2");
            case 3:
                return new GamePiece("Piece 3");
            case 4:
                return new GamePiece("Piece 4");
            case 5:
                return new GamePiece("Piece 5");
            case 6:
                return new GamePiece("Piece 6");
            default:
                return null;
        }
    }
}

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
