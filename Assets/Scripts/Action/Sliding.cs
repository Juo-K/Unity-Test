using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sliding : MonoBehaviour, IAction
{
    [SerializeField]
    private GameObject _particle = null;

    private ActionManager _actionManager = null;
    private Rigidbody _rigidBody = null;

    private NavMeshAgent _navMeshAgent = null;
    private Vector3 _destination;

    private Animator _animator = null;
    private float _speed = 100.0f;
    private bool _bDash = false;

    private Collider[] _colliders = null;

    private GameObject _instantiatedParticle = null;
    private Vector3 _initPos;
    public void Begin(object initValue)
    {
        Debug.Assert(initValue is float, "입력 가능 자료형 : float");
        _actionManager.StartAction(this);
        _speed = (float)initValue;
        _navMeshAgent.enabled = false;

        Vector3 fwd = transform.forward;
        _rigidBody.AddForce(fwd * _speed);

        _animator.SetTrigger("Dash");
        _bDash = true;
        _rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        Invoke("SpawnParticle", 0.2f);
        Invoke("DestroyParticle", 1.0f);
        _initPos = this.transform.position;

        _colliders = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider col in _colliders)
            col.isTrigger = true;
        _rigidBody.useGravity = false;
    }


    private void SpawnParticle()
    {
        _initPos.y += 0.5f;
        if(_instantiatedParticle == null)
            _instantiatedParticle = Instantiate(_particle, _initPos, Quaternion.LookRotation(this.transform.forward));
    }

    private void DestroyParticle()
    {
        if (_instantiatedParticle == null) return;

        ParticleSystem temp = _instantiatedParticle.GetComponent<ParticleSystem>();
        temp.Stop();
        Destroy(_instantiatedParticle);
    }

    public void End()
    {
        _navMeshAgent.enabled = true;
        _bDash = false;
        _rigidBody.constraints = RigidbodyConstraints.None;
        foreach (Collider col in _colliders)
            col.isTrigger = false;
        _rigidBody.useGravity = true;
        //_instantiatedParticle.SetActive(false);

    }

    private float _elapsedTime = 1.0f;
    private float _deltaTime = 0.0f;
    public void Update()
    {
        if (_bDash == false) return;
        if (_deltaTime > _elapsedTime)
        {
            _deltaTime = 0.0f;
            _rigidBody.constraints = RigidbodyConstraints.FreezePosition;

            End();
        }
        else
            _deltaTime += Time.deltaTime;
        //if (_rigidBody.velocity.z < 0.0f)
        //    End();
    }

    private void Awake()
    {
        _rigidBody = this.GetComponent<Rigidbody>();
        _actionManager = this.GetComponent<ActionManager>();
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _animator = this.GetComponent<Animator>();
    }

    private void Start()
    {
       
    }
}
