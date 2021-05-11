using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items")]
public class ItemParams : ScriptableObject
{
    public ItemParamsId ItemParamsId;
    public Mesh ItemMesh;
    public Material ItemMaterial;
    public Sprite ItemSprite;
}

public enum ItemParamsId
{
    Sword,
}