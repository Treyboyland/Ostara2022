using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoPool : MonoBehaviour
{
    [SerializeField]
    MonoBehaviour prefab;


    List<MonoBehaviour> pool = new List<MonoBehaviour>();


    MonoBehaviour CreateObject()
    {
        var instance = Instantiate(prefab, transform);
        instance.gameObject.SetActive(false);

        pool.Add(instance);

        return instance;
    }

    public MonoBehaviour GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        return CreateObject();
    }

    public void DisableAll()
    {
        foreach(var obj in pool)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
