using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Inventory : IEnumerable
{
    [SerializeField]
    List<Item> items;

    public List<Item> Items { get { return items; } }

    public void AddItem(string itemName, int count)
    {
        for (int i = 0; i < items.Count; i++)
        {
            var currentItem = items[i];

            if (currentItem.ItemName == itemName)
            {
                currentItem.Count += count;
                items[i] = currentItem;
                return;
            }
        }

        items.Add(new Item() { ItemName = itemName, Count = count });
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            var currentItem = items[i];

            if (currentItem.ItemName == item.ItemName)
            {
                currentItem.Count += item.Count;
                items[i] = currentItem;
                return;
            }
        }

        items.Add(item);
    }

    public IEnumerator GetEnumerator()
    {
        return items.GetEnumerator();
    }
}
