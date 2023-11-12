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
    private int opponentslot1 = 7;
    private int opponentslot2 = 8;
    private int opponentslot3 = 9;
    private int opponentslot4 = 10;
    private int opponentslot5 = 11;
    private int opponentslot6 = 12;
    
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void inputs()
    {
        
    }

    public void moveByClick(GameObject cardObject, int num)
    {
        originalPosition = cardObject.transform.position;
        originalRotation = cardObject.transform.rotation;
        bool frontrowfull = false;

        if (num == 10 || num == 11 || num == 12)
        {
            frontrowfull = frontRowFullCheck(num);
        }

        if (num == 7 && !isMoving && !slot7check)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot7));
            slot7check = true;
            Debug.Log("Bottom left slot (7) card moved.");
        }
        else if (num == 8 && !isMoving && !slot8check)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot8));
            slot8check = true;
            Debug.Log("Bottom left slot (8) card moved.");
        }
        else if (num == 9 && !isMoving && !slot9check)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot9));
            slot9check = true;
            Debug.Log("Bottom left slot (9) card moved.");
        }
        else if (num == 10 && !isMoving && !slot10check && frontrowfull)
        {
            Debug.Log("Front Row Full check.");
            StartCoroutine(MoveCard(cardObject.transform, slot10));
            slot10check = true;
            Debug.Log("Bottom left slot (10) card moved.");
        }
        else if (num == 11 && !isMoving && !slot11check && frontrowfull)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot11));
            slot11check = true;
            Debug.Log("Bottom left slot (11) card moved.");
        }
        else if (num == 12 && !isMoving && !slot12check && frontrowfull)
        {
            StartCoroutine(MoveCard(cardObject.transform, slot12));
            slot12check = true;
            Debug.Log("Bottom left slot (12) card moved.");
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
