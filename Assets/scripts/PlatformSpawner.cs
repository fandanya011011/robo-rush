using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] protected Platform[] platforms;
    [SerializeField] protected Platform startPlatform;
    [SerializeField] protected int maxPlatformCount;
    [SerializeField] protected float platformLength;
    protected float spawnCoordinate;

    protected Platform GetRandomPlatform()
    {
        int randomIndex = Random.Range(0, platforms.Length);
        return platforms[randomIndex];
    }

    protected virtual void SpawnPlatform(Platform spawnPlatform)
    {
        Instantiate(spawnPlatform, transform.forward * spawnCoordinate,
            transform.rotation);
        spawnCoordinate += platformLength;
    }

    protected virtual void GeneratePlatform()
    {
        SpawnPlatform(startPlatform);
        for (int i = 0; i < maxPlatformCount; i++)
        {
            SpawnPlatform(GetRandomPlatform());
        }
    }
}   
