using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : LivingCreatureActionController
{
    private PlayerCreature _playerCreature;
    private Interactable _lastTarget;
    //private IInteractable _lastTarget;
    public PlayerActionController(PlayerCreature player) : base(player)
    {
        _playerCreature = player;
       
        _playerCreature.ServiceManager.InputController.LeftPionterClickHandler += OnLeftPointerClicked;
    }

    private void OnLeftPointerClicked(Vector3 destination, Collider collider)
    {
        if (_lastTarget != null)
        {
            //.InteractionController
            _lastTarget.OnUnFocus();
        }
        if (collider != null)
        {
            _lastTarget = collider.GetComponent<Interactable>();
            //_lastTarget = collider.GetComponent<IInteractable>();
            if (_lastTarget != null)
            {
                _lastTarget.OnFocus(_playerCreature);
                //_lastTarget.InteractionController.OnFocus(_playerCreature);
                Vector3 centerPoint = new Vector3(_lastTarget.transform.position.x, _playerCreature.transform.position.y, _lastTarget.transform.position.z);
                Move(_lastTarget.transform.position, _lastTarget.StopingDistance);
                //Move(_lastTarget.Body.position, _lastTarget.StopingDistance);
                return;
            }

        }

        Move(destination);
        
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        _playerCreature.ServiceManager.InputController.LeftPionterClickHandler -= OnLeftPointerClicked;
    }
}
