using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Pickup
{
    [SerializeField]
    Item item;

    public override void PickupItem(Player player)
    {
        player.AddToInventory(item);
    }
}
