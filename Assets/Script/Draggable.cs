using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private bool isRightButtonDown = false;
    private Vector3 originalScale;

    private int originalSortingOrder;
    private Renderer objectRenderer;

    private void Start()
    {
        originalScale = transform.localScale;
        objectRenderer = GetComponent<Renderer>();
        originalSortingOrder = objectRenderer.sortingOrder;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            isDragging = true;
            offset = gameObject.transform.position - GetMouseWorldPos();
            // Scale up the object
            transform.localScale *= 1.1f; // You can adjust the scale factor as needed

            // Set the sorting order higher than other blocks
            objectRenderer.sortingOrder = GetHighestSortingOrder() + 1;
        }
        else if (Input.GetMouseButton(1)) // Right mouse button
        {
            RotateObject();
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        // Scale back to original scale
        transform.localScale = originalScale;

        // Restore the original sorting order
        objectRenderer.sortingOrder = originalSortingOrder;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = GetMouseWorldPos();
            gameObject.transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, gameObject.transform.position.z);
            if (Input.GetMouseButtonDown(1)) // Right mouse button pressed
            {
                StartCoroutine(WaitAndRotate());
            }
            else if (Input.GetMouseButtonUp(1)) // Right mouse button released
            {
                StopCoroutine(WaitAndRotate());
            }
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

    IEnumerator WaitAndRotate()
    {
        isRightButtonDown = true;
        yield return new WaitForSeconds(0.05f); // Wait for 0.05 seconds

        // Check again if right mouse button is down after 0.05 seconds
        if (isRightButtonDown)
        {
            RotateObject();
        }
    }

    private int GetHighestSortingOrder()
    {
        // Find the highest sorting order among all objects in the scene
        int highestSortingOrder = int.MinValue;
        Renderer[] renderers = FindObjectsOfType<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            if (renderer.sortingOrder > highestSortingOrder)
            {
                highestSortingOrder = renderer.sortingOrder;
            }
        }
        return highestSortingOrder;
    }
}
