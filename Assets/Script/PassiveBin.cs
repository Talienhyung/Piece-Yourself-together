using UnityEngine;
using UnityEngine.SceneManagement;

public class PassiveBin : MonoBehaviour
{
    public GameObject passivBin;
    private int blocksDeleted = 0;
    public float yOffset = 1f; // Adjust this value to set how much the Y position should increase
    public float gameOverY = 10f; // Set the Y value for triggering game over

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

        // Check if the passivBin has reached the game over Y value
        if (newPosition.y >= gameOverY)
        {
            // Trigger game over here
            Debug.Log("Game Over!");
            // You can add your game over logic here, such as displaying a game over screen or resetting the game.
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Unsubscribe from the event when the object is destroyed
    private void OnDestroy()
    {
        DeleteBlockPassive.OnBlockDeleted -= IncrementBlocksDeleted;
    }
}


