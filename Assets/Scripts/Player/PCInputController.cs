using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PCInputController //: MonoBehaviour
{
    //public static PCInputController Instance;
    private ServiceManager _serviceManager;
    /*public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }*/

    //[SerializeField] private LivingCreature _livingCreature;
    //private NavMeshAgent _navMeshAgent;
    private Camera _cam;
    private bool _leftPointerClicker;

    public Action<Vector3, Collider> LeftPionterClickHandler = delegate { };
    //private Animator _playerAnimator;
    // Start is called before the first frame update
    //void Start()
    public PCInputController(ServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
        Time.timeScale = 1;
        _cam = Camera.main;
        _serviceManager = ServiceManager.Instance;
        _serviceManager.UpdateHandler += OnUpdate;
        //    _serviceManager.UpdateHandler += OnLateUpdate;
        _serviceManager.UpdateHandler += OnFixedUpdate;
        _serviceManager.DestroyHandler += OnDestroy;
        //_navMeshAgent = GetComponent<NavMeshAgent>();
        //_playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnUpdate()
    {
        _leftPointerClicker = Input.GetButton("Fire1");
       

        /*if (Input.GetButton("Fire1"))
        {
            Debug.Log(Input.mousePosition);
        }*/
    }
    private void OnFixedUpdate()
    {
        if (_leftPointerClicker)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out hitInfo, 100))
            {
                LeftPionterClickHandler(hitInfo.point, hitInfo.collider);
                //_livingCreature.ActionController.SetTarget(hitInfo.point, hitInfo.collider);
                //_navMeshAgent.destination = hitInfo.point;
                //_playerAnimator.SetBool("Run", true);
            }
           
        }
        /*if (Vector3.Distance(transform.position, _navMeshAgent.destination) <= _navMeshAgent.stoppingDistance && _playerAnimator.GetBool("Run"))
        {
            _playerAnimator.SetBool("Run", false);
            _navMeshAgent.destination = transform.position;
        }*/
    }

    private void OnDestroy()
    {
        _serviceManager.UpdateHandler -= OnUpdate;
        //    _serviceManager.UpdateHandler -= OnLateUpdate;
        _serviceManager.UpdateHandler -= OnFixedUpdate;
        _serviceManager.DestroyHandler -= OnDestroy;
    }
}
