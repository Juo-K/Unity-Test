using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Damage _target = null;
    private Vector3 _targetPos;

    private float _damage = 0.0f;

    private float _speed;
    public float Speed { set { _speed = value; } }

    private float _lifeTime = 0.0f;
    public float LifeTime { set { _lifeTime = value; } }

    private bool _bHit = false;

    private void Start()
    {
        this.transform.LookAt(_targetPos);
        Invoke("Destroy", _lifeTime);
    }

    private void Update()
    {
        if (_bHit == true) return;

        CalcTargetPos();
        this.transform.LookAt(_targetPos);
        this.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void SetTarget(Damage target, float damage)
    {
        _damage = damage;
        _target = target;
        CalcTargetPos();
    }

    private void CalcTargetPos()
    {

        Vector3 position = _target.transform.position;
        position.y = this.transform.position.y;
        position.y += Random.Range(-1.5f, 1.5f);
        position.x += Random.Range(-1.5f, 1.5f);
        _targetPos = position;
        
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) //RigidBody 가 없으면 돌아가지 않습니다.
    {
        if (other.GetComponent<Damage>() == null) return;

        if (other.tag != "Player")
        {
            _bHit = true;
            AttachArrow(other);
            other.GetComponent<Damage>().Hit(_damage);
        }
    }

    private void AttachArrow(Collider col)
    {
        this.transform.parent = col.transform;
    }

   
}
