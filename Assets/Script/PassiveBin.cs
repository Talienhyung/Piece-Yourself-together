using UnityEngine;

public class PassiveBin : MonoBehaviour
{
    private int blocksDeleted = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the BlockDeleted event
        DeleteBlockPassive.OnBlockDeleted += IncrementBlocksDeleted;
    }

    // Method to increment the number of blocks deleted
    private void IncrementBlocksDeleted()
    {
        blocksDeleted++;
        Debug.Log("Blocks Deleted: " + blocksDeleted);
    }

    // Unsubscribe from the event when the object is destroyed
    private void OnDestroy()
    {
        DeleteBlockPassive.OnBlockDeleted -= IncrementBlocksDeleted;
    }
}
