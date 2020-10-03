using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    public Item item;

    public string item_name;
    public Sprite item_icon;

    private void Start()
    {
        item_name = item.item_name;
        item_icon = item.item_icon;
    }
}
