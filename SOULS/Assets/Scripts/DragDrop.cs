using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        }
    }

    public void StartDrag()
    {
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
    }
}
