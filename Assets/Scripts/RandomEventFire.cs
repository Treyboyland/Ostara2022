using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventFire : MonoBehaviour
{
    [SerializeField]
    List<AK.Wwise.Event> events;

    [SerializeField]
    Vector2 fireRange;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(FireEvents());
        }
    }

    IEnumerator FireEvents()
    {
        while (true)
        {
            float seconds = Random.Range(fireRange.x, fireRange.y);
            yield return new WaitForSeconds(seconds);

            int index = Random.Range(0, events.Count);
            events[index].Post(gameObject);
        }
    }
}
