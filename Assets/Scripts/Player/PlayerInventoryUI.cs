using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryGrid;
    [SerializeField] private Image _movingImage;
    public InventorySlot[] BaseInventorySlots { get; private set; }
    public Image MovingImage => _movingImage;
    public void InitComponents()
    {
        BaseInventorySlots = _inventoryGrid.GetComponentsInChildren<InventorySlot>();
    }
    public InventorySlot GetFreeSlot()
    {
        for(int i=0; i < BaseInventorySlots.Length; i++)
        {
            if (!BaseInventorySlots[i].IsEquiped)
            {
                Debug.Log(i);
                return BaseInventorySlots[i];
            }
        }
        return null;
    }
}
