using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            isDragging = true;
            offset = gameObject.transform.position - GetMouseWorldPos();
        }
        else if (Input.GetMouseButton(1)) // Right mouse button
        {
            RotateObject();
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = GetMouseWorldPos();
            gameObject.transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, gameObject.transform.position.z);
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void RotateObject()
    {
        transform.Rotate(Vector3.forward, 90f);
    }
}

