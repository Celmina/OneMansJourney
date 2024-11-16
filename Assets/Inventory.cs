using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<GameObject> items = new();
    
    public void addItem(GameObject item)
    {
        items.Add(item);
    }

    public void removeItem(GameObject item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
    }

    public bool checkInventory(GameObject item)
    {
        if (items.Contains(item))
        {
            return true;
        }
        return false;
    }
}
