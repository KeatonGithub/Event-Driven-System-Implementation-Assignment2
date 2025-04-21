using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    // declaring variables and storing them in the ItemSO class
    public Image itemImage;
    public string itemName;
    public string itemDescription;
    public int maxStackSize = 64;
    public bool isConsumable;

}
