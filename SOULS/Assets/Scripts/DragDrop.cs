using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{//bool for dragging
    private bool isDragging = false;
    //vector3 for start position
    private Vector3 startPosition;

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {//update the position of the object to the mouse position
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
