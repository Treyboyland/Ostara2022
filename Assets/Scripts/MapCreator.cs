using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField]
    Vector2Int xRange;

    [SerializeField]
    int depth;

    [SerializeField]
    Ground groundPrefab;

    [SerializeField]
    MonoPool gemPickup;

    [SerializeField]
    MonoPool carrotPickup;

    [SerializeField]
    MonoPool tomatoPickup;

    [SerializeField]
    Vector2Int tomatoRange;

    [SerializeField]
    Vector2Int carrotRange;

    [SerializeField]
    Vector2Int gemRange;

    List<Vector3Int> mapIndices = new List<Vector3Int>();

    List<Ground> groundPool = new List<Ground>();

    // Start is called before the first frame update
    void Start()
    {
        CreateMap();
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
        return Random.Range(range.x, range.y);
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

    // Update is called once per frame
    void Update()
    {

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
            }

        }
    }


    void CreatePickups()
    {
        mapIndices.Shuffle();
    }
}
