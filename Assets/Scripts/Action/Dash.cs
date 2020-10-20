using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dash : MonoBehaviour
{
    private Animator _animator = null;
    private Moving _moving = null;
    

    private Vector3 _pos;
    private float _speed = .0f;

    private NavMeshAgent _nav = null;

    [SerializeField, Range(1.0f, 200.0f)]
    private float _range = 100.0f;

    private void Awake()
    {
        _moving = this.GetComponent<Moving>();
        _animator = this.GetComponent<Animator>();
        _nav = this.GetComponent<NavMeshAgent>();
    }
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnDash();
        }
        
    }

    private void OnDash()
    {
        _animator.SetTrigger("Dash");
        
        _pos = this.transform.forward * _speed * Time.deltaTime;
        _nav.destination = this.transform.position + _pos;

    }

    private void OnDashEnd()
    {

    }
}
