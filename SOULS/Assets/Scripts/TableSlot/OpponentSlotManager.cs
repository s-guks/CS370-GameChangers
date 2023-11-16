using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentSlotManager : MonoBehaviour
{
    public Transform slot7;
    public Transform slot8;
    public Transform slot9;
    public Transform slot10;
    public Transform slot11;
    public Transform slot12;
    private GameObject slot7Object = null;
    private GameObject slot8Object = null;
    private GameObject slot9Object = null;
    private GameObject slot10Object = null;
    private GameObject slot11Object = null;
    private GameObject slot12Object = null;
    private bool isMoving = false;
    public float speed = 2.0f;
    public bool interpolateRotation = true;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool slot7check = false;
    private bool slot8check = false;
    private bool slot9check = false;
    private bool slot10check = false;
    private bool slot11check = false;
    private bool slot12check = false;
    /*
    private int opponentslot1 = 7;
    private int opponentslot2 = 8;
    private int opponentslot3 = 9;
    private int opponentslot4 = 10;
    private int opponentslot5 = 11;
    private int opponentslot6 = 12;
    */
    
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void inputs()
    {
        
    }

    public List<int> checkEmpty() //Return Empty Slots
    {
        List<int> emptySlots = new List<int>();

        if (!slot7check)
            emptySlots.Add(7);
        if (!slot8check)
            emptySlots.Add(8);
        if (!slot9check)
            emptySlots.Add(9);
        if (!slot10check)
            emptySlots.Add(10);
        if (!slot11check)
            emptySlots.Add(11);
        if (!slot12check)
            emptySlots.Add(12);
        return emptySlots;
    }

    // Move slots forward after check empty
    public void moveForward()
    {
        List<int> emptySlots = checkEmpty();

        if (slot10check && emptySlots.Contains(7))
        {
            // Move from slot 10 to slot 7
            Debug.Log("Slot 7 is Empty and Slot 10 is Filled");
            Debug.Log("Moving from slot 10 to slot 7");
            StartCoroutine(MoveCard(slot10Object.transform, slot7));
            slot7Object = slot10Object;
            slot10Object = null;
            slot7check = true;
            slot10check = false;
        }
        if (slot11check && emptySlots.Contains(8))
        {
            // Move from slot 11 to slot 8
            Debug.Log("Slot 8 is Empty and Slot 11 is Filled");
            Debug.Log("Moving from slot 11 to slot 8");
            StartCoroutine(MoveCard(slot11Object.transform, slot8));
            slot8Object = slot11Object;
            slot11Object = null;
            slot8check = true;
            slot11check = false;
        }
        if (slot12check && emptySlots.Contains(9))
        {
            // Move from slot 12 to slot 9
            Debug.Log("Slot 9 is Empty and Slot 12 is Filled");
            Debug.Log("Moving from slot 12 to slot 9");
            StartCoroutine(MoveCard(slot12Object.transform, slot9));
            slot9Object = slot12Object;
            slot12Object = null;
            slot9check = true;
            slot12check = false;
        }
    }

    // Allow card objects to be moved from player's hand to opponent's hand
    public void moveByClick(GameObject cardObject, int num)
    {
        originalPosition = cardObject.transform.position;
        originalRotation = cardObject.transform.rotation;
        bool frontrowfull = false;
        isMoving = false;

        if (num == 10 || num == 11 || num == 12)
        {
            frontrowfull = frontRowFullCheck(num);
        }

        if (num == 7 && !isMoving && !slot7check)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot7));
            slot7Object = cardObject;
            slot7check = true;
            Debug.Log("Bottom left slot (7) card moved.");
        }
        else if (num == 8 && !isMoving && !slot8check)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot8));
            slot8Object = cardObject;
            slot8check = true;
            Debug.Log("Bottom left slot (8) card moved.");
        }
        else if (num == 9 && !isMoving && !slot9check)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot9));
            slot9Object = cardObject;
            slot9check = true;
            Debug.Log("Bottom left slot (9) card moved.");
        }
        else if (num == 10 && !isMoving && !slot10check)
        {
            Debug.Log("Front Row Full check.");
            StartCoroutine(MoveCard(cardObject.transform, slot10));
            slot10Object = cardObject;
            slot10check = true;
            Debug.Log("Bottom left slot (10) card moved.");
        }
        else if (num == 11 && !isMoving && !slot11check)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot11));
            slot11Object = cardObject;
            slot11check = true;
            Debug.Log("Bottom left slot (11) card moved.");
        }
        else if (num == 12 && !isMoving && !slot12check)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot12));
            slot12Object = cardObject;
            slot12check = true;
            Debug.Log("Bottom left slot (12) card moved.");
        }else{
            Debug.Log("Error.");
            Debug.Log("num ="+num+", isMoving= "+isMoving+ ", slot7check= "+slot7check);
            Debug.Log("num ="+num+", isMoving= "+isMoving+ ", slot8check= "+slot8check);
            Debug.Log("num ="+num+", isMoving= "+isMoving+ ", slot9check= "+slot9check);
            Debug.Log("num ="+num+", isMoving= "+isMoving+ ", slot10check= "+slot10check+ ", frontrollfull"+frontrowfull);
            Debug.Log("num ="+num+", isMoving= "+isMoving+ ", slot11check= "+slot11check);
            Debug.Log("num ="+num+", isMoving= "+isMoving+ ", slot12check= "+slot12check);
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
        if((slot7check && num == 7) || (slot8check && num == 8) || (slot9check && num == 9))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
