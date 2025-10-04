using UnityEngine;
using System.Collections;

public class SpawController : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] itemPrefabs; // Array of prefabs to spawn
    public float spawnInterval = 0.2f; // Time between spawns
    public int maxItems = 20; // Maximum number of items on the road at once
    
    [Header("Spawn Area")]
    public float minX = -8f;
    public float maxX = 9f;
    public float minZ = 20f;
    public float maxZ = 160f;
    public float spawnHeight = 1f; // Height above ground to spawn items
    
    private int currentItemCount = 0;
    
    void Start()
    {
        // Spawn all items at the start
        SpawnAllItemsAtStart();
    }

    void Update()
    {
        // Clean up destroyed items and update count
        UpdateItemCount();
    }
    
    private void SpawnAllItemsAtStart()
    {
        // Spawn all items at once at the beginning
        for (int i = 0; i < maxItems; i++)
        {
            if (itemPrefabs.Length > 0)
            {
                SpawnRandomItem();
            }
        }
    }
    
    private IEnumerator SpawnItems()
    {
        while (true)
        {
            // Only spawn if we haven't reached the maximum number of items
            if (currentItemCount < maxItems && itemPrefabs.Length > 0)
            {
                SpawnRandomItem();
            }
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
    private void SpawnRandomItem()
    {
        // Choose a random prefab from the array
        GameObject prefabToSpawn = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
        
        // Generate random position within the specified bounds
        Vector3 spawnPosition = new Vector3(
            Random.Range(minX, maxX),
            spawnHeight,
            Random.Range(minZ, maxZ)
        );
        
        // Spawn the item
        GameObject spawnedItem = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        
        // Tag the spawned item for easy identification
        spawnedItem.tag = "SpawnedItem";
        
        // Add a component to auto-destroy after some time (optional)
        ItemLifetime lifetime = spawnedItem.AddComponent<ItemLifetime>();
        lifetime.lifeTime = 30f; // Items will be destroyed after 30 seconds
        
        currentItemCount++;
    }
    
    private void UpdateItemCount()
    {
        // Count current spawned items
        GameObject[] spawnedItems = GameObject.FindGameObjectsWithTag("SpawnedItem");
        currentItemCount = spawnedItems.Length;
    }
    
    // Method to manually spawn an item (can be called from other scripts)
    public void ManualSpawn()
    {
        if (currentItemCount < maxItems && itemPrefabs.Length > 0)
        {
            SpawnRandomItem();
        }
    }
    
    // Method to clear all spawned items
    public void ClearAllItems()
    {
        GameObject[] spawnedItems = GameObject.FindGameObjectsWithTag("SpawnedItem");
        foreach (GameObject item in spawnedItems)
        {
            DestroyImmediate(item);
        }
        currentItemCount = 0;
    }
}

// Helper component to manage item lifetime
public class ItemLifetime : MonoBehaviour
{
    public float lifeTime = 30f;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
