using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hitHandler : MonoBehaviour
{
    public GameObject Player;
    public GameObject winLine;
    public GameObject[] itemPrefabs;
    
    [Header("Game States")]
    public bool gameWon = false;
    public bool playerDead = false;
    
    [Header("UI Elements (Optional)")]
    public GameObject winUI; // Assign a win screen UI if you have one
    public GameObject gameOverUI; // Assign a game over screen UI if you have one
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player exists and game is still active
        if (Player != null && !gameWon && !playerDead)
        {
            CheckWinCondition();
            CheckItemCollisions();
        }
    }
    
    void CheckWinCondition()
    {
        if (winLine != null)
        {
            // Check if player has reached or passed the win line
            if (Player.transform.position.z >= winLine.transform.position.z)
            {
                PlayerWin();
            }
        }
    }
    
    void CheckItemCollisions()
    {
        // Find all spawned items with the "SpawnedItem" tag
        GameObject[] spawnedItems = GameObject.FindGameObjectsWithTag("SpawnedItem");
        
        foreach (GameObject item in spawnedItems)
        {
            if (item != null)
            {
                // Check distance between player and item
                float distance = Vector3.Distance(Player.transform.position, item.transform.position);
                
                // If close enough, consider it a collision (adjust this value as needed)
                if (distance < 2f)
                {
                    PlayerDead();
                    break; // Exit loop since player is dead
                }
            }
        }
    }
    
    void PlayerWin()
    {
        gameWon = true;
        Debug.Log("Player Wins!");
        
        // Stop the game
        Time.timeScale = 0f;
        
        // Show win UI if available
        if (winUI != null)
        {
            winUI.SetActive(true);
        }
    }
    
    void PlayerDead()
    {
        playerDead = true;
        Debug.Log("Player Dead!");
        
        // Stop the game
        Time.timeScale = 0f;
        
        // Show game over UI if available
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }
    
    // Alternative collision detection using Unity's built-in collision system
    // Attach this script to the player and make sure items have colliders with isTrigger = true
    void OnTriggerEnter(Collider other)
    {
        if (!gameWon && !playerDead)
        {
            // Check if hit win line
            if (other.gameObject == winLine)
            {
                PlayerWin();
            }
            // Check if hit any item prefab
            else if (other.CompareTag("SpawnedItem"))
            {
                PlayerDead();
            }
        }
    }
}
