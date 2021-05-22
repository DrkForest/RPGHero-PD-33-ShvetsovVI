using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Items;
using System;

public class InventorySlot : MonoBehaviour, IPointerDownHandler
{
    //private Item _currentItem;
    [SerializeField] protected Image _slotImage;

    public bool IsEquiped { get; private set; }
    public Item SlotItem { get; private set; }

    public bool SlotInteractable { get; protected set; }
    public PlayerCreature PlayerCreature { get; set; }

    public Action<InventorySlot> LeftPointerClicked = delegate { };
    public Action<InventorySlot> RightPointerClicked = delegate { };

    public void AddItemToSlot(Item item)
    {
        if (IsEquiped)
            RemoveItem();

        SlotItem = item;
        IsEquiped = true;
        _slotImage.sprite = SlotItem.InventoryIcon;
        _slotImage.color = Color.white;
    }

    public virtual void RemoveItem()
    {
        _slotImage.sprite = null;
        _slotImage.color = Color.clear;
        SlotItem = null;
        IsEquiped = false;
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftPoiterDown();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (PlayerCreature.PlayerInventoryController.MovingItem != null)
                return;
            OnRightPointerDown();
        }
    }

    protected virtual void OnLeftPoiterDown()
    {
        LeftPointerClicked(this);
        Debug.Log("LeftClick");
    }

    protected virtual void OnRightPointerDown()
    {
        if (!IsEquiped)
            return;

        RightPointerClicked(this);
        Debug.Log("RightClick");
    }

    /*private void OnLeftClick()
    {
        Debug.Log("LeftClick");
    }
    private void OnRightClick()
    {
        Debug.Log("RightClick");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            OnLeftClick();
        if (eventData.button == PointerEventData.InputButton.Right)
            OnRightClick();
    }*/
}
