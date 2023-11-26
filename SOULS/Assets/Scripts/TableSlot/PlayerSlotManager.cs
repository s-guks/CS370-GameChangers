using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSlotManager : MonoBehaviour
{
    public Transform slot1;
    public Transform slot2;
    public Transform slot3;
    public Transform slot4;
    public Transform slot5;
    public Transform slot6;
    private GameObject slot1Object = null;
    private GameObject slot2Object = null;
    private GameObject slot3Object = null;
    private GameObject slot4Object = null;
    private GameObject slot5Object = null;
    private GameObject slot6Object = null;
    public float speed = 2.0f;
    public bool interpolateRotation = true;

    public cardTracker cardTracker;
    public makeDeck makeDeck;
    private bool isMoving = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool hasMoved = false;
    private bool slot1check = false;
    private bool slot2check = false;
    private bool slot3check = false;
    private bool slot4check = false;
    private bool slot5check = false;
    private bool slot6check = false;
    private bool cardSelected = false;
    private GameObject cardObject;

    public void Start()
    {
        cardTracker = GameObject.Find("cardTracker").GetComponent<cardTracker>(); //load reference
        makeDeck = GameObject.Find("makeDeck").GetComponent<makeDeck>(); //load reference
        /*
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        */
    }

    public void Update()
    {
        /*
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        if (!hasMoved)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && !isMoving && !slot1check)
            {
                StartCoroutine(MoveCard(slot1));
                hasMoved = true;
                slot1check = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && !isMoving && !slot2check)
            {
                StartCoroutine(MoveCard(slot2));
                hasMoved = true;
                slot2check = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && !isMoving && !slot3check)
            {
                StartCoroutine(MoveCard(slot3));
                hasMoved = true;
                slot3check = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && !isMoving && !slot4check)
            {
                StartCoroutine(MoveCard(slot4));
                hasMoved = true;
                slot4check = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) && !isMoving && !slot5check)
            {
                StartCoroutine(MoveCard(slot5));
                hasMoved = true;
                slot5check = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6) && !isMoving && !slot6check)
            {
                StartCoroutine(MoveCard(slot6));
                hasMoved = true;
                slot6check = true;
            }
        }
        */
    }

    public void cardClicked(GameObject card)
    {
        cardSelected = true;
        Debug.Log("Card Clicked");
        cardObject = card;
        Vector3 cardPosition = cardObject.transform.position;
        //pass card to whichever function needs it
    }

    public List<int> checkEmpty() //Return Empty Slots
    {
        List<int> emptySlots = new List<int>();

        if (!slot1check)
            emptySlots.Add(1);
        if (!slot2check)
            emptySlots.Add(2);
        if (!slot3check)
            emptySlots.Add(3);
        if (!slot4check)
            emptySlots.Add(4);
        if (!slot5check)
            emptySlots.Add(5);
        if (!slot6check)
            emptySlots.Add(6);
        return emptySlots;
    }

    // Check empty fron slots and move card to forward slots
    public void moveForward()
    {
        List<int> emptySlots = checkEmpty();

        if (slot4check && emptySlots.Contains(1))
        {
            // Move from slot 4 to slot 1
            Debug.Log("Slot 1 is Empty and Slot 4 is Filled");
            Debug.Log("Moving from slot 4 to slot 1");
            StartCoroutine(MoveCard(slot4Object.transform, slot1));
            slot1Object = slot4Object;
            cardTracker.clearSlot(4);
            cardTracker.addToSlot(slot1Object, 1);
            slot4Object = null;
            slot1check = true;
            slot4check = false;
        }
        if (slot5check && emptySlots.Contains(2))
        {
            // Move from slot 5 to slot 2
            Debug.Log("Slot 2 is Empty and Slot 5 is Filled");
            Debug.Log("Moving from slot 5 to slot 2");
            StartCoroutine(MoveCard(slot5Object.transform, slot2));
            slot2Object = slot5Object;
            cardTracker.clearSlot(5);
            cardTracker.addToSlot(slot2Object, 2);
            slot5Object = null;
            slot2check = true;
            slot5check = false;
        }
        if (slot6check && emptySlots.Contains(3))
        {
            // Move from slot 6 to slot 3
            Debug.Log("Slot 3 is Empty and Slot 6 is Filled");
            Debug.Log("Moving from slot 6 to slot 3");
            StartCoroutine(MoveCard(slot6Object.transform, slot3));
            slot3Object = slot6Object;
            cardTracker.clearSlot(6);
            cardTracker.addToSlot(slot3Object, 3);
            slot6Object = null;
            slot3check = true;
            slot6check = false;
        }
    }

    // Move card to desginated location
    public void moveByClick(int num)
    {
        originalPosition = cardObject.transform.position;
        originalRotation = cardObject.transform.rotation;
        bool frontrowfull = false;
        isMoving = false;

        if (num == 4 || num == 5 || num == 6)
        {
            frontrowfull = frontRowFullCheck(num);
            Debug.Log("front row full: " + frontrowfull);
        }

        if (num == 1 && !isMoving && !slot1check)
        {
            checkCardMoveWithinSlot(cardObject.transform);
            Debug.Log("Bottom left slot (1) card moved.");
            cardTracker.removeFromHand(cardObject);
            cardTracker.addToSlot(cardObject, 1);
            
            //discard from deck in makeDeck
            Card c = cardTracker.getScriptable(cardObject);
            int index = makeDeck.Hands["hand1"].IndexOf(c);
            makeDeck.Discard("hand1", index);
            
            StartCoroutine(MoveCard(cardObject.transform, slot1));
            slot1check = true;
            slot1Object = cardObject;
            cardObject = null;
        }
        else if (num == 2 && !isMoving && !slot2check)
        {
            checkCardMoveWithinSlot(cardObject.transform);
            Debug.Log("Bottom left slot (2) card moved.");
            cardTracker.removeFromHand(cardObject);
            cardTracker.addToSlot(cardObject, 2);

            //discard from deck in makeDeck
            Card c = cardTracker.getScriptable(cardObject);
            int index = makeDeck.Hands["hand1"].IndexOf(c);
            makeDeck.Discard("hand1", index);

            StartCoroutine(MoveCard(cardObject.transform, slot2));
            slot2check = true;
            slot2Object = cardObject;
            cardObject = null;

        }
        else if (num == 3 && !isMoving && !slot3check)
        {
            checkCardMoveWithinSlot(cardObject.transform);
            Debug.Log("Bottom left slot (3) card moved.");
            cardTracker.removeFromHand(cardObject);
            cardTracker.addToSlot(cardObject, 3);

            //discard from deck in makeDeck
            Card c = cardTracker.getScriptable(cardObject);
            int index = makeDeck.Hands["hand1"].IndexOf(c);
            makeDeck.Discard("hand1", index);

            StartCoroutine(MoveCard(cardObject.transform, slot3));
            slot3check = true;
            slot3Object = cardObject;
            cardObject = null;

        }
        else if (num == 4 && !isMoving && !slot4check)//&& frontrowfull)
        {
            checkCardMoveWithinSlot(cardObject.transform);
            Debug.Log("Bottom left slot (4) card moved.");
            cardTracker.removeFromHand(cardObject);
            cardTracker.addToSlot(cardObject, 4);

            //discard from deck in makeDeck
            Card c = cardTracker.getScriptable(cardObject);
            int index = makeDeck.Hands["hand1"].IndexOf(c);
            makeDeck.Discard("hand1", index);

            StartCoroutine(MoveCard(cardObject.transform, slot4));
            slot4check = true;
            slot4Object = cardObject;
            cardObject = null;

        }
        else if (num == 5 && !isMoving && !slot5check)// && frontrowfull)
        {
            checkCardMoveWithinSlot(cardObject.transform);
            Debug.Log("Bottom left slot (5) card moved.");
            cardTracker.removeFromHand(cardObject);
            cardTracker.addToSlot(cardObject, 5);

            //discard from deck in makeDeck
            Card c = cardTracker.getScriptable(cardObject);
            int index = makeDeck.Hands["hand1"].IndexOf(c);
            makeDeck.Discard("hand1", index);

            StartCoroutine(MoveCard(cardObject.transform, slot5));
            slot5check = true;
            slot5Object = cardObject;
            cardObject = null;

        }
        else if (num == 6 && !isMoving && !slot6check)// && frontrowfull)
        {
            checkCardMoveWithinSlot(cardObject.transform);
            Debug.Log("Bottom left slot (6) card moved.");
            cardTracker.removeFromHand(cardObject);
            cardTracker.addToSlot(cardObject, 6);

            //discard from deck in makeDeck
            Card c = cardTracker.getScriptable(cardObject);
            int index = makeDeck.Hands["hand1"].IndexOf(c);
            makeDeck.Discard("hand1", index);

            StartCoroutine(MoveCard(cardObject.transform, slot6));
            slot6check = true;
            slot6Object = cardObject;
            cardObject = null;

        }
    }


    IEnumerator MoveCard(Transform cardObject, Transform newLocation)
    {
        isMoving = true;

        // Store the original position and rotation before starting the movement
        Vector3 originalPosition = cardObject.position;
        Quaternion originalRotation = cardObject.rotation;

        Vector3 targetPosition = newLocation.position;
        Quaternion targetRotation = newLocation.rotation;
        float journeyLength = Vector3.Distance(originalPosition, targetPosition);
        float startTime = Time.time;

        while (Time.time - startTime < journeyLength / speed)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;
            cardObject.position = Vector3.Lerp(originalPosition, targetPosition, fractionOfJourney);

            if (interpolateRotation)
            {
                cardObject.rotation = Quaternion.Slerp(originalRotation, targetRotation, fractionOfJourney);
            }

            yield return null;
        }

        // Ensure the card is precisely at the target position and rotation
        cardObject.position = targetPosition;

        if (interpolateRotation)
        {
            cardObject.rotation = targetRotation;
        }

        isMoving = false;
    }

    private void checkCardMoveWithinSlot(Transform trans)
    {
        if (AreTransformsEqual(slot1, trans))
        {
            Debug.Log("Card at Slot 1. Moving from Slot 1...");
            slot1check = false;
        }
        else if (AreTransformsEqual(slot2, trans))
        {
            Debug.Log("Card at Slot 2. Moving from Slot 2...");
            slot2check = false;
        }
        else if (AreTransformsEqual(slot3, trans))
        {
            Debug.Log("Card at Slot 3. Moving from Slot 3...");
            slot3check = false;
        }
        else if (AreTransformsEqual(slot4, trans))
        {
            Debug.Log("Card at Slot 4. Moving from Slot 4...");
            slot4check = false;
        }
        else if (AreTransformsEqual(slot5, trans))
        {
            Debug.Log("Card at Slot 5. Moving from Slot 5...");
            slot5check = false;
        }
        else if (AreTransformsEqual(slot6, trans))
        {
            Debug.Log("Card at Slot 6. Moving from Slot 6...");
            slot6check = false;
        }
        else
        {
            Debug.Log("Card is in hand.");
        }
    }

    public void cardterminate(int slotnum)
    {
        if (slotnum == 1)
        {
            slot1check = false;
            slot1Object = null;
        }
        else if (slotnum == 2)
        {
            slot2check = false;
            slot2Object = null;
        }
        else if (slotnum == 3)
        {
            slot3check = false;
            slot3Object = null;
        }
        else if (slotnum == 4)
        {
            slot4check = false;
            slot4Object = null;
        }
        else if (slotnum == 5)
        {
            slot5check = false;
            slot5Object = null;

        }
        else if (slotnum == 6)
        {
            slot6check = false;
            slot6Object = null;
        }
    }

    bool AreTransformsEqual(Transform t1, Transform t2)
    {
        if (t1 == null || t2 == null)
        {
            // One or both of the transforms are null, consider them not equal
            return false;
        }

        // Compare position, rotation, and scale
        if (t1.position == t2.position && t1.rotation == t2.rotation && t1.localScale == t2.localScale)
        {
            return true;
        }

        return false;
    }
    // Check if front row is full
    bool frontRowFullCheck(int n)
    {
        int num = n - 3;
        if ((slot1check && num == 1) || (slot2check && num == 2) || (slot3check && num == 3))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public float moveSpeed = 5f; // Adjust the speed as needed
    private bool isMovingForward = true;

    void attackanimation()
    {
        if (isMovingForward)
        {
            MoveForward();
        }
        else
        {
            MoveBackward();
        }
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Check if the card has moved far enough forward
        if (transform.position.z >= 5f) // Adjust the threshold as needed
        {
            isMovingForward = false;
        }
    }

    void MoveBackward()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // Check if the card has moved back to the original position
        if (transform.position.z <= 0f) // Assuming the original position is at z = 0
        {
            isMovingForward = true;
        }
    }

}