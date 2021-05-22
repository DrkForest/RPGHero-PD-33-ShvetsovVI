using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _camTransform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _angleOffset;
    [SerializeField] private float _clampRate;

    public float SmoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        _offset = _camTransform.position - _target.position;
    }
    private void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _clampRate);
        //transform.LookAt(_target.position + Vector3.up + _angleOffset);

        // update position
        Vector3 targetPosition = _target.position + _offset;
        _camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

        // update rotation
        transform.LookAt(_target);
    }
}
