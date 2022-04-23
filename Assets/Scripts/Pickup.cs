using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField]
    protected AK.Wwise.Event pickupEvent;

    public abstract void PickupItem(Player player);

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PickupItem(player);
            pickupEvent.Post(gameObject);
            gameObject.SetActive(false);
        }
    }
}
