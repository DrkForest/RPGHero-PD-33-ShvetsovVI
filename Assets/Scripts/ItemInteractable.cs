using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
   [SerializeField] private Item _thisItem;
   protected override void Interact()
    {
        base.Interact();
        _thisItem.Destroy(_player);
    }
}
