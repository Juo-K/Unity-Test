using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour, IAction
{
    private ActionManager _actionManager = null;
    private Animator _animator = null;
    private Vector3 _mPos;
    private Damage _target = null;
    private Damage _thistarget = null;
    
    private Moving _moving = null;

    //[SerializeField, Range(10.0f, 100.0f)]
    //private float _atk = 10.0f;

    //[SerializeField, Range(1.0f, 10.0f)]
    //private float _range = 2.0f;



    [SerializeField]
    private Weapon _intWeapon = null;
    private Weapon _currentWeapon = null;

    [SerializeField]
    private Transform _rightHand = null;


    [SerializeField]
    private Transform _leftHand = null;


    public void Begin(object initValue)
    {
        Damage target = initValue as Damage;
        
        Debug.Assert(target != null, "입력 가능 자료형 : Damage");

        _actionManager.StartAction(this);
        _target = target;
    }

    public void End()
    {
        _target = null;
        _animator.ResetTrigger("Attack");
    }

    private void Awake()
    {
        _actionManager = this.GetComponent<ActionManager>();
        _animator = this.GetComponent<Animator>();
        _moving = this.GetComponent<Moving>();
        _thistarget = this.GetComponent<Damage>();
    }

    private void Update()
    {
        if (_target == null) return;

        if (_thistarget.Dead == true) return;
                

        Vector2 a = new Vector2(_target.transform.position.x, _target.transform.position.z);
        Vector2 b = new Vector2(this.transform.position.x, this.transform.position.z);

        if (_currentWeapon == null) return;

        if (Vector2.Distance(a, b) < _currentWeapon.Range)
        {
            _moving.End();
            this.transform.LookAt(_target.transform.position);
            _animator.SetTrigger("Attack");
        }
        else
            _moving.Move(_target.transform.position);
    }

    private void OnAttack()
    {
        if (_target == null) return;

        Debug.Log("Attack!");
        _target.Hit(_currentWeapon.Damage);
    }

    private void OnAttackEnd()
    {
        //_animator.ResetTrigger("Attack");
        End();
    }

    public void Equip(Weapon weapon)
    {
        _currentWeapon = weapon;
        _currentWeapon.Spawn(_rightHand, _leftHand,_animator);
    }

    private void OnDrawGizmos()
    {

        if (_currentWeapon == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, _currentWeapon.Range);
    }

}

