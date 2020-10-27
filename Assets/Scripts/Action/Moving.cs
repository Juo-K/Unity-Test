using System;
using UnityEngine;
using UnityEngine.AI;

public class Moving : MonoBehaviour, IAction
{
    private ActionManager _actionManager = null;
    private Rigidbody _rigidBody = null;

    private NavMeshAgent _navMeshAgent = null;
    private Vector3 _destination;

    private Animator _animator = null;
    private float _speed = 0.0f;

    public void Begin(object initValue)
    {
        if (_navMeshAgent.enabled == false) return;
        Debug.Assert(initValue is Vector3, "입력 가능 자료형 : Vector3");
        _actionManager.StartAction(this);
        Vector3 destination = (Vector3)initValue;
       
        Move(destination);
    }

    public void Move(Vector3 destination)
    {
        _navMeshAgent.isStopped = false;
        _navMeshAgent.destination = destination;

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion") == false)
        {
            _navMeshAgent.destination = this.transform.position;
        }
    }

    public void End()
    {
        if (_navMeshAgent.enabled == false) return;

            _navMeshAgent.isStopped = true;
    }


    private void Awake()
    {
        _rigidBody = this.GetComponent<Rigidbody>();
        _actionManager = this.GetComponent<ActionManager>();
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        //if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        //{
        //    _navMeshAgent.destination = this.transform.position;
        //}
    }

    private void FixedUpdate()
    {
        Vector3 velocity = _navMeshAgent.velocity;
        Vector3 local = this.transform.InverseTransformDirection(velocity);
        _speed = velocity.magnitude / _navMeshAgent.speed;
        _animator.SetFloat("Speed", _speed);
    }

   
}
