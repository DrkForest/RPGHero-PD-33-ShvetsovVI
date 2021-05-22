using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : Interactable
{
    protected override void Interact()
    {
        base.Interact();
        Debug.Log("Hello " + _player + " I`m NPC: " + gameObject);
    }
}
