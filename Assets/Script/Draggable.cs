using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private bool isRightButtonDown = false;

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
            if (Input.GetMouseButtonDown(1)) // Bouton droit de la souris enfoncé
            {
                StartCoroutine(WaitAndRotate());
            }
            else if (Input.GetMouseButtonUp(1)) // Bouton droit de la souris relâché
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
        yield return new WaitForSeconds(0.05f); // Attendre 1 seconde

        // Vérifier à nouveau si le bouton droit de la souris est enfoncé après 1 seconde
        if (isRightButtonDown)
        {
            RotateObject();
        }
    }
}