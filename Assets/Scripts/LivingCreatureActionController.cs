using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingCreatureActionController //: MonoBehaviour
{
    [SerializeField] private LivingCreature _livingCreature;
    
    private ActionType _currentAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //public void Init()
    public LivingCreatureActionController(LivingCreature livingCreature)
    {
        _livingCreature = livingCreature;
        _livingCreature.ServiceManager.DestroyHandler += OnDestroy;
        _livingCreature.ServiceManager.UpdateHandler += OnUpdate;
    }

    protected virtual void Move(Vector3 destenation, float stoppingDistance = 0.5f)
    {
        _livingCreature.CreatureNavMeshAgent.destination = destenation;
        _livingCreature.CreatureNavMeshAgent.stoppingDistance = stoppingDistance;
        ChangeAction(ActionType.Run);
    }

    // Update is called once per frame
    protected virtual void OnUpdate()
    {
        if (Vector3.Distance(_livingCreature.transform.position, _livingCreature.CreatureNavMeshAgent.destination) <= _livingCreature.CreatureNavMeshAgent.stoppingDistance)
        {
            ChangeAction(ActionType.Idle);
            _livingCreature.CreatureNavMeshAgent.destination = _livingCreature.transform.position;
        }
    }
    

    protected virtual void ChangeAction(ActionType action)
    {
        ResetAction();
        _currentAction = action;
        if(_currentAction != ActionType.Idle)
        {
            _livingCreature.CreatureAnimator.SetBool(_currentAction.ToString(), true);
        }
        

    }

    protected virtual void ResetAction()
    {
        if(_currentAction != ActionType.Idle)
        {
            _livingCreature.CreatureAnimator.SetBool(_currentAction.ToString(), false);
        }
        _currentAction = ActionType.Idle;
    }

    protected virtual void OnDestroy()
    {
        _livingCreature.ServiceManager.DestroyHandler -= OnDestroy;
        _livingCreature.ServiceManager.UpdateHandler -= OnUpdate;
        
    }
}

public enum ActionType
{
    Idle,
    Walk,
    Run,
    Sprint,
    Attack,
    Hurt,
    Death,
}
