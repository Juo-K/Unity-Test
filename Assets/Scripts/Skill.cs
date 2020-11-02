using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skill : MonoBehaviour,IAction
{ 
    private ActionManager _actionManager = null;
    private Animator _animator = null;
    private Damage _target = null;
    private Damage _thistarget = null;

    private NavMeshAgent _navMeshAgent = null;

    private Moving _moving = null;
    //private Collider[] _colliders = null;

    [SerializeField]
    private Weapon _intWeapon = null;
    private Weapon _currentWeapon = null;

    [SerializeField]
    private Transform _rightHand = null;


    [SerializeField]
    private Transform _leftHand = null;

    private bool _multishot = false;
    public bool multishot { get { return _multishot; } set { _multishot = value; } }

    private bool _returnshot = false;
    

    private int _skillnum = 0;


    public void Begin(object initValue)
    {
        Debug.Assert(initValue is int, "입력 가능 자료형 : int");
        _actionManager.StartAction(this);
        _skillnum = (int)initValue;
        //_navMeshAgent.enabled = false;

        if (_skillnum == 1)
        {

            _multishot = true;
            _animator.SetTrigger("Attack");
        }

        if(_skillnum ==2)
        {
            _returnshot = true;
            _animator.SetTrigger("Attack");
        }



       
    }

    public void End()
    {
        _multishot = false;
        _target = null;
        _animator.ResetTrigger("Attack");
        //_navMeshAgent.enabled = true;
    }

    public void Start()
    {
        if (_intWeapon == null) return;
        Equip(_intWeapon);
    }

    private void Awake()
    {
        _actionManager = this.GetComponent<ActionManager>();
        _animator = this.GetComponent<Animator>();
        _moving = this.GetComponent<Moving>();
        _thistarget = this.GetComponent<Damage>();
    }

    private void OnAttack()
    {
        if (_currentWeapon.HasProjectile == true)
        {
            _currentWeapon.LaunchProjectile(_rightHand, _leftHand, _target);
        }
        else
            _target.Hit(_currentWeapon.Damage);
    }

    private float _elapsedTime = 2.0f;
    private float _deltaTime = 0.0f;
    private void Update()
    {
        if (_thistarget.Dead == true) return;
        if (_currentWeapon == null) return;

        Damage target = GameObject.Find("Enemy").GetComponent<Damage>();
        _target = target;


        if (_deltaTime > _elapsedTime)
        {
            _deltaTime = 0.0f;
            End();
        }
        else
            _deltaTime += Time.deltaTime;

        if(_returnshot == true)
        {

        }

    }

    private void OnAttackEnd()
    {
        //_animator.ResetTrigger("Attack");
        End();
    }

    public void Equip(Weapon weapon)
    {
        _currentWeapon = weapon;
        _currentWeapon.Spawn(_rightHand, _leftHand, _animator);
    }

    private void SkillEnd()
    {
        _multishot = false;
    }

  
}
