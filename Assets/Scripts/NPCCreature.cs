using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCreature : LivingCreature//, IInteractable
{


    /*[SerializeField] private float _interactionDistance;
    public InteractionController InteractionController { get; protected set; }

    public float InteractionDistance => _interactionDistance;

    public Transform Body => transform;

    public virtual float StopingDistance => _interactionDistance * 0.8f;

    protected override void Start()
    {
        base.Start();
        InteractionController = new NPCInteractionController(this);

    }
    private void OnDestroy()
    {
        InteractionController.Destroy();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _interactionDistance);
    }*/
}
