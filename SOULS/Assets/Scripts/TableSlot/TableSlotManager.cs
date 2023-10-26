using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSlotManager : MonoBehaviour
{
    public GameObject[] cardHolders;  // Array to store card holder game objects
    public GameObject cardObjectPrefab;  // Reference to the card object prefab
    private GameObject[] occupiedSlots;  // Array to store occupied slot status
    private GameObject selectedCard;    // The currently selected card object
    private int selectedSlot = -1;      // The selected card holder slot, initially -1 to indicate no slot selected

    private void Start()
    {
        occupiedSlots = new GameObject[cardHolders.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectSlot(i);
            }
        }

        // Check for input to place the selected card
        if (selectedCard != null && selectedSlot >= 0 && !IsSlotOccupied(selectedSlot))
        {
            PlaceCard(selectedSlot);
        }
    }

    void SelectSlot(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < cardHolders.Length)
        {
            selectedSlot = slotIndex;
            Debug.Log("Selected slot: " + (slotIndex + 1));
        }
    }

    bool IsSlotOccupied(int slotIndex)
    {
        return occupiedSlots[slotIndex] != null;
    }

    void PlaceCard(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < cardHolders.Length)
        {
            if (!IsSlotOccupied(slotIndex))
            {
                GameObject cardHolder = cardHolders[slotIndex];
                GameObject newCardObject = Instantiate(cardObjectPrefab, cardHolder.transform);
                newCardObject.transform.localPosition = Vector3.zero; // You may need to adjust the card's position.
                occupiedSlots[slotIndex] = newCardObject; // Mark the slot as occupied
                selectedCard = null; // Reset the selected card
                selectedSlot = -1; // Reset the selected slot
                Debug.Log("Placed card in slot: " + (slotIndex + 1));
            }
            else
            {
                Debug.Log("Slot " + (slotIndex + 1) + " is already occupied.");
            }
        }
    }
}
