using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractable : Interactable
{
    protected override void Interact()
    {
        base.Interact();
        Debug.Log("Hello " + _player + " I`m Enemy: " + gameObject);
    }
}
