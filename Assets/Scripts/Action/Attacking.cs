using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour, IAction
{
    private ActionManager _actionManager = null;
    private Animator _animator = null;
    private Vector3 _mPos;
    private Damage _target = null;
    private Moving _moving = null;

    [SerializeField, Range(1.0f, 10.0f)]
    private float _range = 1.0f; //타겟 사이의 거리가 2.0f일때 작동

    public void Beging(object initValue)
    {
        Damage target = initValue as Damage; // Damage로 변할 수 있으면 반환 아니면 null
        Debug.Assert(target != null, "입력 가능 자료형  : Damage");

        _actionManager.StartAction(this); // 스크립트 자체를 넘김;
        _target = target;

    }

    public void End()
    {
        _target = null; // Damage
        _animator.ResetTrigger("Attack");
    }

    private void Awake()
    {
        _actionManager = this.GetComponent<ActionManager>();
        _animator = this.GetComponent<Animator>();
        _moving = this.GetComponent<Moving>();
    }
   
    void Update()
    {
        if (_target == null) return;

        Vector2 a = new Vector2(_target.transform.position.x, _target.transform.position.z);
        Vector2 b = new Vector2(this.transform.position.x, this.transform.position.z);

        if(Vector2.Distance(a,b) < _range)
        {
            _moving.End();
            this.transform.LookAt(_target.transform.position);
            _animator.SetTrigger("Attack");
        }
        else
        {
            _moving.Move(_target.transform.position);
        }
    }

    private void OnAttack()
    {
        Debug.Log("Attack!");
        _target.Hit();
    }

    private void OnAttackEnd()
    {
        //_animator.ResetTrigger("Attack");
        End();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, _range);
    }

}
