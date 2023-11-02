using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
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

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
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
    }

    IEnumerator MoveCard(Transform newLocation)
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
            transform.position = Vector3.Lerp(originalPosition, targetPosition, fractionOfJourney);

            if (interpolateRotation)
            {
                transform.rotation = Quaternion.Slerp(originalRotation, targetRotation, fractionOfJourney);
            }

            yield return null;
        }

        transform.position = targetPosition;

        if (interpolateRotation)
        {
            transform.rotation = targetRotation;
        }

        isMoving = false;
    }
}