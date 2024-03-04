using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Array to hold the prefabs of the game objects
    public Transform spawnPoint; // Set the spawn point where you want the blocks to appear
    public float tickRate = 1f; // Adjust this value to change tick rate
    private float timer;
    public float customGravity = 5f;

    // Chance of a special event happening per tick (expressed as a percentage)
    public float specialEventChance = 10f; // 10% chance by default

    // Special event variables
    public GameObject[] lovePrefabs;
    public GameObject[] TraumaPrefabs;
    public GameObject[] RestPrefabs;
    public GameObject[] MentalRestPrefabs;
    public int specialEventDurationTicks = 5; // Duration of the special event in ticks
    private bool isSpecialEventActive = false;
    private int specialEventTickCounter = 0;

    private enum SpecialEventType
    {
        Love,
        Trauma,
        Rest,
        MentalRest
    }

    private SpecialEventType currentSpecialEventType; // To store the current special event type

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tickRate)
        {
            // Trigger tick event
            Tick();
            timer = 0f; // Reset the timer
        }
    }

    private void Tick()
    {
        if (isSpecialEventActive)
        {
            specialEventTickCounter++;
            if (specialEventTickCounter >= specialEventDurationTicks)
            {
                // Special event duration is over, deactivate the special event
                isSpecialEventActive = false;
                specialEventTickCounter = 0; // Reset the tick counter
            }
            else
            {
                // Spawn the appropriate special event object based on the current special event type
                switch (currentSpecialEventType)
                {
                    case SpecialEventType.Love:
                        SpawnLoveObject();
                        break;
                    case SpecialEventType.Trauma:
                        SpawnTraumaObject();
                        break;
                    case SpecialEventType.Rest:
                        SpawnRestObject();
                        break;
                    case SpecialEventType.MentalRest:
                        SpawnMentalRestObject();
                        break;
                }
            }
        }
        else
        {
            // Check if the special event should happen
            if (Random.Range(0f, 100f) <= specialEventChance)
            {
                // Activate the special event
                ActivateSpecialEvent();
            }
            else
            {
                // Normal block spawning
                SpawnNormalBlock();
            }
        }
    }



    private void SpawnNormalBlock()
    {
        // Randomly select one of the prefabs
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject prefabToSpawn = objectPrefabs[randomIndex];

        // Generate a random X offset within the range of +2 and -2
        float randomXOffset = Random.Range(-2f, 2f);

        // Generate a random rotation angle in increments of 90 degrees (0, 90, 180, or 270 degrees)
        float randomRotation = Random.Range(0, 4) * 90f;

        // Calculate the spawn position with the random X offset
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x + randomXOffset, spawnPoint.position.y, spawnPoint.position.z);

        // Spawn the selected prefab at the calculated spawnPosition with the random rotation
        GameObject newBlock = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Rotate the spawned block by the random rotation angle around the Z-axis
        newBlock.transform.Rotate(Vector3.forward, randomRotation);
        // Add Rigidbody component to the spawned block

        Rigidbody2D rb = newBlock.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        BoxCollider2D box = newBlock.AddComponent<BoxCollider2D>();

        // Add CustomGravity component to the spawned block
        CustomGravity customGravityComponent = newBlock.AddComponent<CustomGravity>();
        customGravityComponent.downwardForce = customGravity; // Set the custom gravity value
    }

    private void SpawnLoveObject()
    {
        int randomIndex = Random.Range(0, lovePrefabs.Length);
        GameObject prefabToSpawn = lovePrefabs[randomIndex];
        // Spawn the special prefab
        // Generate a random X offset within the range of +2 and -2
        float randomXOffset = Random.Range(-2f, 2f);

        // Generate a random rotation angle in increments of 90 degrees (0, 90, 180, or 270 degrees)
        float randomRotation = Random.Range(0, 4) * 90f;

        // Calculate the spawn position with the random X offset
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x + randomXOffset, spawnPoint.position.y, spawnPoint.position.z);

        // Spawn the selected prefab at the calculated spawnPosition with the random rotation
        GameObject newBlock = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Rotate the spawned block by the random rotation angle around the Z-axis
        newBlock.transform.Rotate(Vector3.forward, randomRotation);
        // Add Rigidbody component to the spawned block
        Rigidbody2D rb = newBlock.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        BoxCollider2D box = newBlock.AddComponent <BoxCollider2D>();

        // Add CustomGravity component to the spawned block
        CustomGravity customGravityComponent = newBlock.AddComponent<CustomGravity>();
        customGravityComponent.downwardForce = customGravity; // Set the custom gravity value
    }

    private void SpawnTraumaObject()
    {
        int randomIndex = Random.Range(0, TraumaPrefabs.Length);
        GameObject prefabToSpawn = TraumaPrefabs[randomIndex];
        // Spawn the special prefab
        // Generate a random X offset within the range of +2 and -2
        float randomXOffset = Random.Range(-2f, 2f);

        // Generate a random rotation angle in increments of 90 degrees (0, 90, 180, or 270 degrees)
        float randomRotation = Random.Range(0, 4) * 90f;

        // Calculate the spawn position with the random X offset
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x + randomXOffset, spawnPoint.position.y, spawnPoint.position.z);

        // Spawn the selected prefab at the calculated spawnPosition with the random rotation
        GameObject newBlock = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Rotate the spawned block by the random rotation angle around the Z-axis
        newBlock.transform.Rotate(Vector3.forward, randomRotation);
        // Add Rigidbody component to the spawned block
        Rigidbody2D rb = newBlock.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        BoxCollider2D box = newBlock.AddComponent<BoxCollider2D>();

        // Add CustomGravity component to the spawned block
        CustomGravity customGravityComponent = newBlock.AddComponent<CustomGravity>();
        customGravityComponent.downwardForce = customGravity; // Set the custom gravity value
    }

    private void SpawnRestObject()
    {
        int randomIndex = Random.Range(0, RestPrefabs.Length);
        GameObject prefabToSpawn = RestPrefabs[randomIndex];
        // Spawn the special prefab
        // Generate a random X offset within the range of +2 and -2
        float randomXOffset = Random.Range(-2f, 2f);

        // Generate a random rotation angle in increments of 90 degrees (0, 90, 180, or 270 degrees)
        float randomRotation = Random.Range(0, 4) * 90f;

        // Calculate the spawn position with the random X offset
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x + randomXOffset, spawnPoint.position.y, spawnPoint.position.z);

        // Spawn the selected prefab at the calculated spawnPosition with the random rotation
        GameObject newBlock = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Rotate the spawned block by the random rotation angle around the Z-axis
        newBlock.transform.Rotate(Vector3.forward, randomRotation);
        // Add Rigidbody component to the spawned block
        Rigidbody2D rb = newBlock.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        BoxCollider2D box = newBlock.AddComponent<BoxCollider2D>();

        // Add CustomGravity component to the spawned block
        CustomGravity customGravityComponent = newBlock.AddComponent<CustomGravity>();
        customGravityComponent.downwardForce = customGravity; // Set the custom gravity value
    }

    private void SpawnMentalRestObject()
    {
        int randomIndex = Random.Range(0, RestPrefabs.Length);
        GameObject prefabToSpawn = RestPrefabs[randomIndex];
        // Spawn the special prefab
        // Generate a random X offset within the range of +2 and -2
        float randomXOffset = Random.Range(-2f, 2f);

        // Generate a random rotation angle in increments of 90 degrees (0, 90, 180, or 270 degrees)
        float randomRotation = Random.Range(0, 4) * 90f;

        // Calculate the spawn position with the random X offset
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x + randomXOffset, spawnPoint.position.y, spawnPoint.position.z);

        // Spawn the selected prefab at the calculated spawnPosition with the random rotation
        GameObject newBlock = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Rotate the spawned block by the random rotation angle around the Z-axis
        newBlock.transform.Rotate(Vector3.forward, randomRotation);
        // Add Rigidbody component to the spawned block
        Rigidbody2D rb = newBlock.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        BoxCollider2D box = newBlock.AddComponent<BoxCollider2D>();

        // Add CustomGravity component to the spawned block
        CustomGravity customGravityComponent = newBlock.AddComponent<CustomGravity>();
        customGravityComponent.downwardForce = customGravity; // Set the custom gravity value
    }

    private void ActivateSpecialEvent()
    {
        isSpecialEventActive = true;
        specialEventTickCounter = 0; // Reset the tick counter

        // Decide which special event to activate based on their respective probabilities
        float randomEventChance = Random.Range(0f, 100f);
        float loveChance = 50f;
        float traumaChance = 5f;
        float restChance = 30f;
        float mentalRestChance = 15f;

        if (randomEventChance < loveChance)
        {
            currentSpecialEventType = SpecialEventType.Love;
        }
        else if (randomEventChance < loveChance + traumaChance)
        {
            currentSpecialEventType = SpecialEventType.Trauma;
        }
        else if (randomEventChance < loveChance + traumaChance + restChance)
        {
            currentSpecialEventType = SpecialEventType.Rest;
        }
        else
        {
            currentSpecialEventType = SpecialEventType.MentalRest;
        }
    }
}

