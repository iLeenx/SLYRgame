using UnityEngine;
using System.Collections;

public class BGGenerator : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] items;        // array of prefabs to choose from
    public Vector3 startPoint = new Vector3(7, 7, 7);
    public Vector3 endPoint = new Vector3(14, 14, 14);
    public float spawnInterval = 20f;

    [Header("Item Movement")]
    public float moveSpeed = 5f;

    private GameObject currentItem;

    private void Start()
    {
        StartCoroutine(SpawnItemRoutine());
    }

    private IEnumerator SpawnItemRoutine()
    {
        while (true)
        {
            if (currentItem == null && items.Length > 0)
            {
                int randomIndex = Random.Range(0, items.Length);
                currentItem = Instantiate(items[randomIndex], startPoint, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Update()
    {
        if (currentItem != null)
        {
            // move the item toward endPoint
            currentItem.transform.position = Vector3.MoveTowards(
                currentItem.transform.position,
                endPoint,
                moveSpeed * Time.deltaTime
            );

            // destroy the item if it reaches the endPoint
            if (currentItem.transform.position == endPoint)
            {
                Destroy(currentItem);
                currentItem = null;
            }
        }
    }
}
