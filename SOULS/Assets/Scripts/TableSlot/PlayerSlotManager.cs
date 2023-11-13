using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void cardClicked(GameObject card){
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
            slot4Object = null;
            slot1check = true;
            slot4check = false;
        }
        else if (slot5check && emptySlots.Contains(2))
        {
            // Move from slot 5 to slot 2
            Debug.Log("Slot 2 is Empty and Slot 5 is Filled");
            Debug.Log("Moving from slot 5 to slot 2");
            StartCoroutine(MoveCard(slot5Object.transform, slot2));
            slot2Object = slot5Object;
            slot5Object = null;
            slot2check = true;
            slot5check = false;
        }
        else if (slot6check && emptySlots.Contains(3))
        {
            // Move from slot 6 to slot 3
            Debug.Log("Slot 3 is Empty and Slot 6 is Filled");
            Debug.Log("Moving from slot 6 to slot 3");
            StartCoroutine(MoveCard(slot6Object.transform, slot3));
            slot3Object = slot6Object;
            slot6Object = null;
            slot3check = true;
            slot6check = false;
        }
    }
    public void moveByClick(int num)
    {
        originalPosition = cardObject.transform.position;
        originalRotation = cardObject.transform.rotation;
        bool frontrowfull = false;
        isMoving = false;

        if (num == 4 || num == 5 || num == 6)
        {
            frontrowfull = frontRowFullCheck(num);
            Debug.Log(frontrowfull);
        }

        if (num == 1 && !isMoving && !slot1check)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot1));
            slot1Object = cardObject;
            cardObject = null;
            slot1check = true;
            Debug.Log("Bottom left slot (1) card moved.");
        }
        else if (num == 2 && !isMoving && !slot2check)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot2));
            slot2Object = cardObject;
            cardObject = null;
            slot2check = true;
            Debug.Log("Bottom left slot (2) card moved.");
        }
        else if (num == 3 && !isMoving && !slot3check)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot3));
            slot3Object = cardObject;
            cardObject = null;
            slot3check = true;
            Debug.Log("Bottom left slot (3) card moved.");
        }
        else if (num == 4 && !isMoving && !slot4check )//&& frontrowfull)
        {
            Debug.Log("Front Row Full check.");
            StartCoroutine(MoveCard(cardObject.transform, slot4));
            slot4Object = cardObject;
            cardObject = null;
            slot4check = true;
            Debug.Log("Bottom left slot (4) card moved.");
        }
        else if (num == 5 && !isMoving && !slot5check)// && frontrowfull)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot5));
            slot5Object = cardObject;
            cardObject = null;
            slot5check = true;
            Debug.Log("Bottom left slot (5) card moved.");
        }
        else if (num == 6 && !isMoving && !slot6check)// && frontrowfull)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot6));
            slot6Object = cardObject;
            cardObject = null;
            slot6check = true;
            Debug.Log("Bottom left slot (6) card moved.");
        }
    }


    IEnumerator MoveCard(Transform cardObject, Transform newLocation)
    {
        isMoving = true;
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

        cardObject.position = targetPosition;

        if (interpolateRotation)
        {
            cardObject.rotation = targetRotation;
        }

        isMoving = false;
    }

    // Check if front row is full
    bool frontRowFullCheck(int n)
    {
        int num = n - 3;
        if((slot1check && num == 1) || (slot2check && num == 2) || (slot3check && num == 3))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}