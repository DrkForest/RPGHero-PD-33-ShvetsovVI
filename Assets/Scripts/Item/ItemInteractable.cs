using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
   //[SerializeField] private ItemBody _thisItem;

    ItemBody _itemBody;
    protected override void Start()
    {
        _itemBody = GetComponent<ItemBody>();
        base.Start();
    }

    protected override void Interact()
    {
        base.Interact();
        //_thisItem.Destroy(_player);
        _itemBody.OnPickUp(_player);
    }
}
