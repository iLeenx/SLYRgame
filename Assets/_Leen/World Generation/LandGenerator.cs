using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandGenerator : MonoBehaviour
{
    public GameObject[] land; // land prefabs
    public Transform player;         // Reference to the player

    [SerializeField] private int maxLandsInScene = 5;
    [SerializeField] private Vector3 startPos = Vector3.zero;
    [SerializeField] private float landLength = 20f;   // length of land prefab
    [SerializeField] private float moveSpeed = 7f;

    private Queue<GameObject> activeLands = new Queue<GameObject>();

    void Start()
    {
        // when the game starts we spawn maxLandsInScene lands in a row
        for (int i = 0; i < maxLandsInScene; i++)
        {
            SpawnLand();
        }
    }

    void Update()
    {
        MoveLands();
        CheckLandsBehindPlayer();
    }

    void SpawnLand()
    {
        // Choose a random prefab
        int landNum = Random.Range(0, land.Length);

        // Calculate spawn position
        Vector3 spawnPos = startPos;

        if (activeLands.Count > 0)
        {
            // Attach to the end of the last land
            GameObject lastLand = activeLands.Peek();

            foreach (GameObject l in activeLands) 
            {
                lastLand = l; // get last land in queue
            }
            
            spawnPos = lastLand.transform.position + new Vector3(0, 0, landLength);
        }

        // Instantiate the new land at the calculated position
        GameObject newLand = Instantiate(land[landNum], spawnPos, Quaternion.identity);

        // Add the new land to the queue of active lands
        activeLands.Enqueue(newLand);

        // If over max, destroy oldest land
        if (activeLands.Count > maxLandsInScene)
        {
            // remove the first land
            GameObject oldLand = activeLands.Dequeue(); 
            Destroy(oldLand);
        }
    }

    void MoveLands()
    {
        //Moves each land backward along the Z-axis.
        foreach (GameObject land in activeLands)
        {
            // Move land along the negative Z-axis
            land.transform.position -= new Vector3(0, 0, moveSpeed * Time.deltaTime);
        }
    }

    void CheckLandsBehindPlayer()
    {
        if (activeLands.Count == 0) return;

        GameObject firstLand = activeLands.Peek();

        // If the land is completely behind the player
        if (firstLand.transform.position.z + landLength < player.position.z)
        {
            // Destroy the land behind player
            Destroy(firstLand);
            activeLands.Dequeue();

            // Spawn a new land at the front
            SpawnLand();
        }
    }
}