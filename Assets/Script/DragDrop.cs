using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject ObjectDragToPos;

    public float Dropdistance;

    public bool isLocked;

    Vector2 objectinitPos;
    // Start is called before the first frame update
    void Start()
    {
        objectinitPos = objectToDrag.transform.position;
    }

    public void DragObject()
    {
        if (!isLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }

    public void DropObject()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, ObjectDragToPos.transform.position);
        if(Distance < Dropdistance)
        {
            objectToDrag.transform.position = ObjectDragToPos.transform.position;
            isLocked = true;
        }
        else
        {
            objectToDrag.transform.position = objectinitPos;
        }
    }

    public void Update()
    {
        if (isLocked)
        {
            objectToDrag.transform.position = ObjectDragToPos.transform.position;
        }
    }
}
