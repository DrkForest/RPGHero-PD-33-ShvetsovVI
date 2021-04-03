using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Interactable : MonoBehaviour
{
    private bool _isFocused;
    private bool _hasInteracted;
    protected PlayerCreature _player;
    [SerializeField]private float _interactableDistance;
    public float StopingDistance { 
        get { return _interactableDistance * 0.7f; } 
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

    void Update()
    {
        if(_isFocused && _player != null)
        {
            Vector3 centerPoint = new Vector3(transform.position.x, _player.transform.position.y, transform.position.z);
            if (Vector3.Distance(centerPoint, _player.transform.position) < _interactableDistance && !_hasInteracted)
            {
                Interact();
            }
        }
        
    }
    protected virtual void Interact()
    {
        _hasInteracted = true;
        Debug.Log("HasInteracted");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _interactableDistance);
    }
}
