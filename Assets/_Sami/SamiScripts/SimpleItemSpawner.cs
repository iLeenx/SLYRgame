using System;
using UnityEngine;

public class SimpleItemSpawner : MonoBehaviour
{
    [Header("Drag Your Buff Prefabs Here")]
    public GameObject buff1;
    public GameObject buff2;
    public GameObject buff3;
    public GameObject buff4;

    [Header("Spawn Timing")]
    public float spawnInterval = 3f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandomBuff();
            timer = 0f;
        }
    }

    void SpawnRandomBuff()
    {
        int randomIndex = UnityEngine.Random.Range(0, 4);


        GameObject selected = null;

        if (randomIndex == 0) selected = buff1;
        if (randomIndex == 1) selected = buff2;
        if (randomIndex == 2) selected = buff3;
        if (randomIndex == 3) selected = buff4;

        if (selected != null)
        {
            Instantiate(selected, transform.position, transform.rotation);
        }
    }
}
