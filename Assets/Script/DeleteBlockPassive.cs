using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlockPassive : MonoBehaviour
{
    public float deleteLvl = -6f;
    private Draggable draggableScript; // Reference to Draggable script

    // Define a delegate type for the event
    public delegate void BlockDeleted();
    // Define a static event to be raised when the block is deleted
    public static event BlockDeleted OnBlockDeleted;

    private void Start()
    {
        // Get the Draggable script component attached to this GameObject
        draggableScript = GetComponent<Draggable>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the block's Y position is below -6 and if it's not locked
        if (transform.position.y < deleteLvl && (draggableScript == null || !draggableScript.locked))
        {
            // Raise the OnBlockDeleted event
            OnBlockDeleted?.Invoke();
            // Destroy the block
            Destroy(gameObject);
        }
    }
}
