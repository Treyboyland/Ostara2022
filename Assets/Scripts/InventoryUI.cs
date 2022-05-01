using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    MonoPool itemUIPool;

    private void Awake()
    {
        player.OnInventoryUpdated.AddListener(UpdateUI);
    }

    void UpdateUI()
    {
        itemUIPool.DisableAll();
        foreach (var item in player.Inventory)
        {
            if (item.ItemName == "Carrot" || item.ItemName == "Gem")
            {
                continue;
            }
            for (int i = 0; i < item.Count; i++)
            {
                var obj = (PickupUI)itemUIPool.GetObject();
                obj.SetItem(item);
                obj.gameObject.SetActive(true);
            }
        }
    }
}
