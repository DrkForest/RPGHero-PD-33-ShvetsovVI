using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    InteractionController InteractionController { get; }

    float InteractionDistance { get; }
    float StopingDistance { get; }

    Transform Body { get; }
}
public abstract class InteractionController
{
    private bool _isFocused;
    private bool _hasInteracted;
    protected PlayerCreature _player;

    private IInteractable _thisInteractable;

    public InteractionController(IInteractable interactable)
    {
        _thisInteractable = interactable;
        ServiceManager.Instance.UpdateHandler += OnUpdate;
    }
    public void OnFocus(PlayerCreature player)
    {
        _isFocused = true;
        _player = player;
    }
    public void OnUnFocus()
    {
        _isFocused = false;
        _hasInteracted = false;
    }

    private void OnUpdate()
    {
        if (_isFocused && _player != null)
        {
            if (Vector3.Distance(_thisInteractable.Body.position, _player.transform.position) < _thisInteractable.InteractionDistance && !_hasInteracted)
            {
                Interact();
            }
        }

    }
    protected virtual void Interact()
    {
        _hasInteracted = true;
        Debug.Log("hasInteracted");
    }

    public void Destroy()
    {
        ServiceManager.Instance.UpdateHandler -= OnUpdate;
    }
}
public class NPCInteractionController : InteractionController
{
    public NPCInteractionController(IInteractable interactable) : base(interactable)
    {

    }
}