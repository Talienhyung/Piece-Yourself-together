using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Calculate offset from mouse position to object position
            offset = transform.position - GetMouseWorldPosition();
            isDragging = true;
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Update object position while dragging
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;
        // Convert mouse position to world space
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
