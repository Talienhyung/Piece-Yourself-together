using UnityEngine;

public class PassiveBin : MonoBehaviour
{
    public GameObject passivBin;
    private int blocksDeleted = 0;
    public float yOffset = 1f; // Adjust this value to set how much the Y position should increase

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

        // Adjust the Y position of passivBin
        Vector3 newPosition = passivBin.transform.position;
        newPosition.y += yOffset;
        passivBin.transform.position = newPosition;
    }

    // Unsubscribe from the event when the object is destroyed
    private void OnDestroy()
    {
        DeleteBlockPassive.OnBlockDeleted -= IncrementBlocksDeleted;
    }
}

