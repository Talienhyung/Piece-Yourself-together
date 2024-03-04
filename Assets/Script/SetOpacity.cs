using UnityEngine;

public class SetOpacity : MonoBehaviour
{
    public float opacity = 0.5f; // Set the opacity value here (0 for fully transparent, 1 for fully opaque)

    void Start()
    {
        // Ensure the game object has a renderer component
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            // Get the material of the object
            Material mat = rend.material;
            // Get the current color
            Color color = mat.color;
            // Set the alpha value of the color
            color.a = opacity;
            // Set the updated color back to the material
            mat.color = color;
        }
    }
}