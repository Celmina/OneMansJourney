using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    List<GameObject> items = new();
    
    public void addItem(GameObject item)
    {
        items.Add(item);
        Debug.Log($"Item Added: {item.name}");
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

    public void DisplayInventory()
{
    foreach (var item in items)
    {
        Debug.Log($"Inventory Item: {item.name}");
    }
}
}
