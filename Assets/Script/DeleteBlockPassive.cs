using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlockPassive : MonoBehaviour
{
    public float deleteLvl = -6f;
    // Define a delegate type for the event
    public delegate void BlockDeleted();
    // Define a static event to be raised when the block is deleted
    public static event BlockDeleted OnBlockDeleted;

    // Update is called once per frame
    void Update()
    {
        // Check if the block's Y position is below -6
        if (transform.position.y < deleteLvl)
        {
            // Raise the OnBlockDeleted event
            OnBlockDeleted?.Invoke();
            // Destroy the block
            Destroy(gameObject);

        }
    }
}
