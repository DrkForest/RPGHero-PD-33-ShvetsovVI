using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class ItemBody : MonoBehaviour
{
    [SerializeField] private ItemBase _itemBase;
    private MeshRenderer _MeshRenderer;
    private MeshFilter _MeshFilter;
    private Collider _itemCollider;
    private Item _item;
    //private ItemParams _itemParams;
    
    private void Start()
    {
        _MeshRenderer = GetComponent<MeshRenderer>();
        _MeshFilter = GetComponent<MeshFilter>();
        _itemCollider = GetComponent<Collider>();
        _item = new Equipment(_itemBase as EquipmentBase);
    }

    public void Init(Mesh itemMesh, Material itemMaterial, Item item)
    {
        _MeshRenderer.material = itemMaterial;
        _MeshFilter.mesh = itemMesh;
        _itemCollider = gameObject.AddComponent<Collider>();
        _item = item;
        //_itemParams = itemParams;
        //Reset item Collider
    }

   /* public void Destroy(PlayerCreature player)
    {
        if (player.PlayerInventory.AddItemToInventory(_item))
        {
            _item.SetOwner(player);
            Destroy(gameObject);
        }
        Debug.Log(player);
       
    }*/
    public void OnPickUp(PlayerCreature player)
    {
        if (player.PlayerInventoryController.AddItemToInventory(_item))
        {
            Debug.Log("Destroy");
            _item.SetOwner(player);
            Destroy(gameObject);
            //Destroy(_itemCollider);
        }
    }
}
