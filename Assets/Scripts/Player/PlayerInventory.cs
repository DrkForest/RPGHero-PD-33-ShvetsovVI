using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory 
{
    private PlayerCreature _player;
    private List<ItemParams> _inventoryItems = new List<ItemParams>();
    private int _invetoryCapasity = 100;

    public PlayerInventory(PlayerCreature player)
    {
        _player = player;
    }

    public bool AddItemToInventory(ItemParams item)
    {
        if (_inventoryItems.Count < _invetoryCapasity)
        {
            _inventoryItems.Add(item);
            ShowInventoryItems();
            return true;
        }
        else
            return false;

    }

    private void ShowInventoryItems()
    {
        foreach (ItemParams inventoryItem in _inventoryItems)
        {
            Debug.Log(inventoryItem.ItemId);
        }
    }
    public void RemoveItemFromInventory()
    {

    }
}
