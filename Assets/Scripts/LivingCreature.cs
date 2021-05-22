using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

[RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public abstract class LivingCreature : MonoBehaviour
{
    public Rigidbody CreatureRB { get; private set; }
    public Collider CreatureCollider { get; private set; }
    public NavMeshAgent CreatureNavMeshAgent { get; private set; }
    public Animator CreatureAnimator { get; private set; }
    public ServiceManager ServiceManager { get; private set; }

    //[SerializeField] private LivingCreatureController _actionController;
    public LivingCreatureActionController ActionController { get; protected set; }

    /*[SerializeField] private PlayerController playerController;

    public PlayerController PlayerController => playerController;*/

    public Action DestroyHandler = delegate { };

    // Start is called before the first frame update
    protected virtual void Start()
    {
        CreatureRB = GetComponent<Rigidbody>();
        CreatureCollider = GetComponent<Collider>();
        CreatureNavMeshAgent = GetComponent<NavMeshAgent>();
        CreatureAnimator = GetComponent<Animator>();
        ServiceManager = ServiceManager.Instance;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnDestroy()
    {
        DestroyHandler();
    }
}
