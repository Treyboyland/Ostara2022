using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Inventory : IEnumerable<Item>
{
    [SerializeField]
    List<Item> items;

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

    public int GetNumberOfItem(string itemName)
    {
        int count = 0;
        foreach (var item in items)
        {
            if (item.ItemName == itemName)
            {
                count += item.Count;
            }
        }

        return count;
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

    public void RemoveItem(string itemName, int count = 1)
    {
        for (int i = 0; i < items.Count; i++)
        {
            var currentItem = items[i];

            if (currentItem.ItemName == itemName)
            {
                currentItem.Count = Mathf.Max(0, currentItem.Count - count);
                items[i] = currentItem;
                return;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        //Explicit interface implementation https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/explicit-interface-implementation
        return GetEnumerator();
    }


    public IEnumerator<Item> GetEnumerator()
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}
