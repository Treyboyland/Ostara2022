using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Item
{
    [SerializeField]
    string itemName;

    public string ItemName { get { return itemName; } set { itemName = value; } }

    [SerializeField]
    int count;

    public int Count { get { return count; } set { count = value; } }

}
