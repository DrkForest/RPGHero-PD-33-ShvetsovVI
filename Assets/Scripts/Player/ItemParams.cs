using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items")]
public class ItemParams : ScriptableObject
{
    public ItemId ItemId;
    public Mesh ItemMesh;
    public Material ItemMaterial;
    public Sprite ItemSprite;
}

public enum ItemId
{
    Sword,
}