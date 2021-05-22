using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerWindow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _playerWindow;
    [SerializeField] private PlayerInventoryUI _playerInventory;
    [SerializeField] private PlayerEquipmentUI _playerEquipment;
    
    public bool PointerOverWindow { get; private set; }
    public PlayerInventoryUI PlayerInventory => _playerInventory;
    public PlayerEquipmentUI PlayerEquipment => _playerEquipment;

    public void InitComponents()
    {
        Debug.Log("1");
        ServiceManager.Instance.InputController.CharacterWindowClicked += ChangeWindowState;
        //ServiceManager.Instance.ExitBtnController.ExitBtnClicked += ChangeWindowState;
        _playerEquipment.InitComponents();
        _playerInventory.InitComponents();
        
        _playerWindow.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerOverWindow = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerOverWindow = false;
    }

    private void ChangeWindowState()
    {
        Debug.Log("Open-close");
        _playerWindow.SetActive(!_playerWindow.activeInHierarchy);
    }

    private void OnDestroy()
    {
        ServiceManager.Instance.InputController.CharacterWindowClicked -= ChangeWindowState;
        //ServiceManager.Instance.ExitBtnController.ExitBtnClicked -= ChangeWindowState;
    }
}
