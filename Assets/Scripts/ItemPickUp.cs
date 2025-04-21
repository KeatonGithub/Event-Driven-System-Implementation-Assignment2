using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemSO item;
    public GameObject KeyObj;
    public GameObject Door;
    public int amount = 1;
    public bool isKeyCollected = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>(); //geting the inventory


        if (inventory)
        {
            inventory.AddItem(item, amount);
            Destroy(gameObject);
            CheckKey();

        }

    }

    public void CheckKey()
    {
        if (KeyObj != null)
        {
           // Inventory inventory = GetComponent<Inventory>(); //geting the inventory
                                                                   // If the key is found, open the door
            Destroy(Door);
           isKeyCollected = true;
           // inventory.RemoveItem(item, amount); code that is intended to remove the key after it has been used
           
        }
    }



}
