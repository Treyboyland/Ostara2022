using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerBark : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    AK.Wwise.Event barkEvent;

    [SerializeField]
    Vector2 secondsBetweenBarks;

    bool isBarking = false;

    void Awake()
    {
        player.OnInventoryUpdated.AddListener(CheckForBarks);
    }

    private void OnDisable()
    {
        StopBarking();
    }

    void StopBarking()
    {
        StopAllCoroutines();
        isBarking = false;
    }

    void CheckForBarks()
    {
        if (!isBarking && player.Inventory.GetNumberOfItem("Carrot") < 2)
        {
            StartCoroutine(StartBarking());
        }
    }

    IEnumerator StartBarking()
    {
        isBarking = true;
        while (true)
        {
            barkEvent.Post(gameObject);
            yield return new WaitForSeconds(Random.Range(secondsBetweenBarks.x, secondsBetweenBarks.y));
        }
    }

}
