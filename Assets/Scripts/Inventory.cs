using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
}

public class Inventory : MonoBehaviour
{
    public Dictionary<ItemSO,int> inventory = new Dictionary<ItemSO,int>();
    public int maxInventorySlots = 50;


    public delegate void OnInventoryChanged();
    public event OnInventoryChanged onInventoryUpdated;

    // Start is called before the first frame update
public void AddItem(ItemSO newItem, int amount)
    {
        if (inventory.ContainsKey(newItem))
        {
            inventory[newItem] += amount;
        }
        else
        {
            if(inventory.Count >= maxInventorySlots)
            {
                Debug.Log("Inventory is full!");
                return;
            }

            inventory.Add(newItem, amount);
        }
        onInventoryUpdated?.Invoke();
    }
    public void RemoveItem(ItemSO itemToRemove, int amount)
    {
        if (inventory.ContainsKey(itemToRemove))
        {
            inventory[itemToRemove] -= amount;
            if (inventory[itemToRemove] <= 0)
            {
                inventory.Remove(itemToRemove);
            }
            //update inventory UI here
            onInventoryUpdated?.Invoke();
        }
    }

    public bool hasItem(ItemSO item, int amount)
    {
        return inventory.ContainsKey(item) && inventory[item] >= amount;
    }
}
