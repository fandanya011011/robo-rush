using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlatformSpawner : PlatformSpawner
{
    [SerializeField] private Platform finalPlatform;

    protected override void GeneratePlatform()
    {
        base.GeneratePlatform();
        SpawnPlatform(finalPlatform);
    }

    private void Start()
    {
        GeneratePlatform();
    }
}
