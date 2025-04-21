using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;

    public Transform inventoryPanel;
    public GameObject inventorySlotPrefab;

    private List<GameObject> slots = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();

        inventory.onInventoryUpdated += UpdateUI;
    }

    private void OnDestroy()
    {
        inventory.onInventoryUpdated -= UpdateUI;
    }
    private void UpdateUI()
    {
        //clear old slots, then create new slots from the inventory dictionry

        foreach (var slot in slots)
        {
            Destroy(slot);
            slots.Clear();
        }
        foreach(KeyValuePair<ItemSO, int> entry in inventory.inventory)
        {
            GameObject newSlot = Instantiate(inventorySlotPrefab, inventoryPanel);
            newSlot.GetComponentInChildren<TextMeshProUGUI>().text = entry.Key.itemName + " :" + entry.Value;
           // newSlot.GetComponentInChildren<Image>().sprite = entry.Key.itemImage.sprite;
            slots.Add(newSlot);
        }
    }
}
