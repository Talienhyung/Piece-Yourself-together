using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeed = 100f; // Vitesse de défilement, à ajuster selon vos besoins

    private void Update()
    {
        float scrollDirection = Input.mouseScrollDelta.y;

        if (scrollDirection > 0)
        {
            // Si le défilement est vers le haut, déplacer l'objet vers le haut
            transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
        }
        else if (scrollDirection < 0)
        {
            // Si le défilement est vers le bas, déplacer l'objet vers le bas
            transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        }
    }
}
