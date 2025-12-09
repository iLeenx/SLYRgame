using System;
using UnityEngine;

public class SimpleItemSpawner : MonoBehaviour
{
    [Header("Drag Your Buff Prefabs Here")]
    public GameObject buff1;
    public GameObject buff2;
    public GameObject buff3;

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
        int randomIndex = UnityEngine.Random.Range(0, 3);


        GameObject selected = null;

        if (randomIndex == 0) selected = buff1;
        if (randomIndex == 1) selected = buff2;
        if (randomIndex == 2) selected = buff3;

        if (selected != null)
        {
            Instantiate(selected, transform.position, transform.rotation);
        }
    }
}
