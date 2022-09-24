using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;

    public int numberOfPlatforms;
    public float levelWidth = 3f;
    public float minY = 3.5f;
    public float maxY = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    } 
}
