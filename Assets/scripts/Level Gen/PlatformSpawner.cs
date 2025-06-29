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

    [SerializeField] protected GameObject coinPrefab;
    [SerializeField] protected float lineSpacing;
    protected float spawnDirection;
    [SerializeField] protected GameObject cratePrefab;

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
            SpawnCoin(spawnCoordinate);
        }
    }

    protected virtual GameObject SpawnCoin(float zPos)
    {
        int row = Random.Range(0, 3) - 1;
        if (row == -1)
        {
            Instantiate(cratePrefab, new(lineSpacing * 0, 1f, zPos), Quaternion.identity);
            Instantiate(cratePrefab, new(lineSpacing * 1, 1f, zPos), Quaternion.identity);
        }
        if (row == 0)
        {
            Instantiate(cratePrefab, new(lineSpacing * -1, 1f, zPos), Quaternion.identity);
            Instantiate(cratePrefab, new(lineSpacing * 1, 1f, zPos), Quaternion.identity);
        }
        if (row == 1)
        {
            Instantiate(cratePrefab, new(lineSpacing * -1, 1f, zPos), Quaternion.identity);
            Instantiate(cratePrefab, new(lineSpacing * 0, 1f, zPos), Quaternion.identity);
        }
        Vector3 pos = new(lineSpacing*row, 2f, zPos);
        return Instantiate(coinPrefab, pos, Quaternion.identity);
    }
}   
