using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandGenerator : MonoBehaviour
{
    public GameObject[] land; // land prefabs
    private bool createLands = false;
    private int landNum;

    //[SerializeField] private int zPos;  // starting point
    //[SerializeField] private int zGap; // how far each land from the other
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 gapPos;
    [SerializeField] private float destroyAfter;
    [SerializeField] private float respawnTime;

    // Update is called once per frame
    void Update()
    {
        if (createLands == false)
        {
            createLands = true;
            StartCoroutine(LandGen());
        }
    }

    IEnumerator LandGen()
    {
        landNum = Random.Range(0, land.Length);
        //Instantiate(land[landNum], new Vector3(0, 0, zPos), Quaternion.identity);

        // spawn & store reference
        GameObject spawnedLand = Instantiate(land[landNum], startPos, Quaternion.identity);
        // destroy after 20 seconds
        Destroy(spawnedLand, destroyAfter);

        startPos += gapPos;
        yield return new WaitForSeconds(respawnTime);
        createLands = false;
    }
}
