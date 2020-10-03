using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // List for inventory items
    public List<Item> items;

    // Inventory game objects
    private Transform inv_Parent;

    // Prefab for displaying items
    public GameObject inv_Prefab;

    // Inventory size, so we're not adding & instantiating objects when our inventory is full!
    private int inventorySize;

    private void Start()
    {
        // Create the list
        items = new List<Item>();

        inv_Parent = GameObject.Find("inv_Parent").transform;

        // Get the inventory size
        inventorySize = inv_Parent.childCount;
    }

    public void LoadInventory()
    {
        // The current inventory slot we're on
        // Getting the child object method returns an array, so start at 0.
        int current = 0;

        // Get the items in the list
        foreach (Item item in items)
        {
            // Make sure we are not instantiating an object when we're over the inventory size
            if (current < inventorySize)
            {
                // Get the slot parent
                Transform slotParent = inv_Parent.GetChild(current);

                // Check and see if there's an object already there
                if (slotParent.childCount > 0)
                {
                    // Delete the Game Object
                    foreach (Transform child in transform) Destroy(child.gameObject);
                }

                // Instantiate the GameObject under the slotParent
                var newItem = Instantiate<GameObject>(inv_Prefab, transform);
                newItem.transform.GetChild(0).GetComponent<Image>().sprite = item.item_icon;
                newItem.transform.GetChild(1).GetComponent<Text>().text = item.item_name;

                // Increase the current slot by one, so we're not instantiating in the same slot
                current++;
            }
        }
    }

    public void AddItemToInventory(Item item)
    {
        // Check if we have inventory space
        if (items.Count < inventorySize)
        {
            // Add the item to the list
            items.Add(item);

            // Reload the inventory
            LoadInventory();
        }
    }

    public void RemoveItemFromInventory(string itemName)
    {
        foreach (Item item in items)
        {
            // If the item is found
            if (item.item_name == itemName)
            {
                // Remove the item from the inventory
                items.Remove(item);

                // Reload the inventory
                LoadInventory();

                // Break the loop incase we have more than one object with the same name
                break;
            }
        }
    }
}
