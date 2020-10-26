//using UnityEngine;
//using UnityEngine.AI;

//public class Sliding : MonoBehaviour, IAction
//{
//    [SerializeField]
//    private GameObject _particle = null;

//    private ActionManager _actionManager = null;
//    private Rigidbody _rigidbody = null;

//    private NavMeshAgent _navMeshAgent = null;
//    private Vector3 _destination;

//    private Animator _animator = null;

//    private float _speed = 100.0f;
//    private bool _bDash = false;

//    private GameObject _instantiatedParticle = null;
//    //private void Begin(object initValue)
//    //{
//    //   
//    //}


//    //private void End()
//    //{
//    //    _navMeshAgent.enabled = true;
//    //    _bDash = false; _rigidbody.constraints = RigidbodyConstraints.None;
//    //}

//    private float _elapsedTime = 1.0f;
//    private float _deltaTime = 0.0f;


//    void Update()
//    {
//        if (_bDash == false) return;
//        if (_deltaTime > _elapsedTime)
//        {
//            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
//            _deltaTime = 0.0f;
//            End();
//        }
//        else
//            _deltaTime += Time.deltaTime;

//        //if(_rigidBody.velocity.z < 0.0f)
//        //End();
//    }

//    private void Awake()
//    {
//        _rigidbody = this.GetComponent<Rigidbody>();
//        _navMeshAgent = this.GetComponent<NavMeshAgent>();
//        _animator = this.GetComponent<Animator>();
//        _actionManager = this.GetComponent<ActionManager>();

//    }

//    public void Begin(object initValue)
//    {

//        Debug.Assert(initValue is float, " 입력 가능 자료형 : float");
//        _actionManager.StartAction(this); //
//        _speed = (float)initValue;
//        _navMeshAgent.enabled = false;

//        Vector3 fwd = transform.forward;

//        _rigidbody.AddForce(fwd * _speed);

//        _animator.SetTrigger("Dash");
//        _bDash = true; // update를 돌리기 위한 변수;
//        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

//        _instantiatedParticle = Instantiate(_particle, this.transform.position, this.transform.rotation);//인스턴스를 생성, 위치 ,방향;

//    }

//    public void End()
//    {
//        _navMeshAgent.enabled = true;
//        _bDash = false;
//        _rigidbody.constraints = RigidbodyConstraints.None;
//        _instantiatedParticle.SetActive(false);
//        Destroy(_instantiatedParticle);
//    }
//}

//using UnityEngine;
//using UnityEngine.AI;

//public class Sliding : MonoBehaviour, IAction
//{
//    [SerializeField]
//    private GameObject _particle = null;

//    private ActionManager _actionManager = null;
//    private Rigidbody _rigidbody = null;

//    private NavMeshAgent _navMeshAgent = null;
//    private Vector3 _destination;

//    private Animator _animator = null;
//    private float _speed = 100.0f;
//    private bool _bDash = false;

//    private GameObject _instantiatedParticle = null;
//    public void Begin(object initValue)
//    {
//        if (_bDash) return;
//        Debug.Assert(initValue is float, "입력 가능 자료형 : float");
//        _actionManager.StartAction(this);
//        _speed = (float)initValue;
//        _navMeshAgent.enabled = false;

//        Vector3 fwd = transform.forward;
//        _rigidbody.AddForce(fwd * _speed);

//        _animator.SetTrigger("Dash");
//        _bDash = true;
//        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
//        _instantiatedParticle = Instantiate(_particle, this.transform.rotation * this.transform.position, this.transform.rotation);
//    }

//    public void End()
//    {
//        _navMeshAgent.enabled = true;
//        _bDash = false;
//        _rigidbody.constraints = RigidbodyConstraints.None;
//        Destroy(_instantiatedParticle);
//    }

//    private void Awake()
//    {
//        _actionManager = this.GetComponent<ActionManager>();
//        _animator = this.GetComponent<Animator>();
//        _navMeshAgent = this.GetComponent<NavMeshAgent>();
//        _rigidbody = this.GetComponent<Rigidbody>();
//    }

//    private float _deltaTime = 0.0f;
//    private float _elapsedTime = 1.0f;
//    private void Update()
//    {
//        if (_bDash == false) return;
//        if (_deltaTime > _elapsedTime)
//        {
//            _deltaTime = 0.0f;
//            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
//            End();
//        }
//        else
//            _deltaTime += Time.deltaTime;
//    }
//}


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

    private GameObject _instantiatedParticle = null;
    private Vector3 _initPos;
    public void Begin(object initValue)
    {
        Debug.Assert(initValue is float, "입력 가능 자료형 : float");
        _actionManager.StartAction(this);
        _speed = (float)initValue;
        _navMeshAgent.enabled = false;

        Vector3 fwd = transform.forward;
        Vector3 uwd = transform.up;
        _rigidBody.AddForce((fwd ) *  _speed);
        _rigidBody.AddForce((uwd ) *  _speed / 4);

        _animator.SetTrigger("Dash");
        _bDash = true;
        _rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        Invoke("SpawnParticle", 0.5f);
        Invoke("DestroyParticle", 1.0f);
        _initPos = this.transform.position;
    }


    private void SpawnParticle()
    {
        _initPos.y += 0.5f;

        if (_instantiatedParticle != null)
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