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
        //pass card to whichever function needs it
    }

    public void moveByClickInt(int num)
    {
        //if(cardSelected = true){slots can be clicked}
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        frontRowFullCheck();
        if (num==1 && !isMoving && !slot1check)
    
    public void moveByClick(Transform cardObject, int num)
    {
        originalPosition = cardObject.position;
        originalRotation = cardObject.rotation;
        bool frontrowfull = false;

        if (num == 4 || num == 5 || num == 6)
        {
            frontrowfull = frontRowFullCheck(num);
        }

        if (num == 1 && !isMoving && !slot1check)
        {
            StartCoroutine(MoveCard(cardObject, slot1));
            slot1check = true;
            Debug.Log("Bottom left slot (1) card moved.");
        }
        else if (num == 2 && !isMoving && !slot2check)
        {
            StartCoroutine(MoveCard(cardObject, slot2));
            slot2check = true;
            Debug.Log("Bottom left slot (2) card moved.");
        }
        else if (num == 3 && !isMoving && !slot3check)
        {
            StartCoroutine(MoveCard(cardObject, slot3));
            slot3check = true;
            Debug.Log("Bottom left slot (3) card moved.");
        }
        else if (num == 4 && !isMoving && !slot4check && frontrowfull)
        {
            Debug.Log("Front Row Full check.");
            StartCoroutine(MoveCard(cardObject, slot4));
            slot4check = true;
            Debug.Log("Bottom left slot (4) card moved.");
        }
        else if (num == 5 && !isMoving && !slot5check && frontrowfull)
        {
            StartCoroutine(MoveCard(cardObject, slot5));
            slot5check = true;
            Debug.Log("Bottom left slot (5) card moved.");
        }
        else if (num == 6 && !isMoving && !slot6check && frontrowfull)
        {
            StartCoroutine(MoveCard(cardObject, slot6));
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

    // Check if front row is full, prevent move card to backrow if front row is not full
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