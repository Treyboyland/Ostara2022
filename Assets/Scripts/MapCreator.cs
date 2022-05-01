using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapCreator : MonoBehaviour
{
    [SerializeField]
    Vector2Int xRange;

    [SerializeField]
    int depth;

    [SerializeField]
    Ground groundPrefab;

    [SerializeField]
    HomeBase homeBase;

    List<Vector3Int> mapIndices = new List<Vector3Int>();

    List<Ground> groundPool = new List<Ground>();

    List<Ground> currentGround = new List<Ground>();

    [SerializeField]
    List<PickupData> pickups;



    [Serializable]
    struct PickupData
    {
        public MonoPool Pool;
        public Vector2Int Range;
    }

    private void Awake()
    {
        homeBase.OnBaseReached.AddListener(() =>
        {
            ResetGround();
            CreatePickups();
        });
    }


    // Start is called before the first frame update
    void Start()
    {
        CreateMap();
        CreatePickups();
    }

    Ground CreateGround()
    {
        var instance = Instantiate(groundPrefab, transform);
        instance.gameObject.SetActive(false);

        groundPool.Add(instance);

        return instance;
    }

    int GetRandomInt(Vector2Int range)
    {
        return UnityEngine.Random.Range(range.x, range.y);
    }

    Ground GetGround()
    {
        foreach (var ground in groundPool)
        {
            if (!ground.gameObject.activeInHierarchy)
            {
                return ground;
            }
        }

        return CreateGround();
    }

    void ResetGround()
    {
        foreach (var ground in currentGround)
        {
            ground.ResetGround();
        }
    }

    void CreateMap()
    {
        if (xRange.x > xRange.y)
        {
            throw new System.Exception("Starting bound should be less than end bound");
        }
        for (int x = xRange.x; x < xRange.y; x++)
        {
            for (int y = -1; y >= -depth; y--)
            {
                Vector3 position = new Vector3(x, y, transform.position.z);
                mapIndices.Add(new Vector3Int(x, y, (int)transform.position.z));
                var ground = GetGround();
                ground.SetLocation(position);
                ground.gameObject.SetActive(true);
                currentGround.Add(ground);
            }

        }
    }

    void CreateSpawn(ref int startingIndex, MonoPool pool, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = pool.GetObject();
            obj.transform.position = mapIndices[startingIndex];
            obj.gameObject.SetActive(true);
            startingIndex++;
        }
    }


    void CreatePickups()
    {
        mapIndices.Shuffle();
        int index = 0;

        foreach (var data in pickups)
        {
            data.Pool.DisableAll();
            CreateSpawn(ref index, data.Pool, GetRandomInt(data.Range));
        }
    }
}
