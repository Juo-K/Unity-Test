﻿using UnityEngine;
using UnityEngine.AI;

public class Moving : MonoBehaviour
{
    //목적지를 찍어야줘얌

    private NavMeshAgent _navMeshAgent = null;
    private Vector3 _destination;
    private Vector3 _thisPosition;
    private NavMeshPath _path = null;
    private Vector3[] _corners = null;

    private Animator _animator = null;
    private float _speed = 0.0f;

    private void Awake()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _animator = this.GetComponent<Animator>();
    }

    void Update()
    {
       if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//화면좌표계 상의 좌표를 반직선으로 바꿈; 바꾸고 싶은 값을 안에 집어넣음;
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 500))//물체의 좌표까지 무조건감;
            {
                _navMeshAgent.destination = hit.point; //충돌된 위치까지가 목적지;
                _destination = hit.point; //누른 위치가 목적지;
                _path = _navMeshAgent.path;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 velocity = _navMeshAgent.velocity; //방향이 있는 것; 속력 월드방향; local로 끌어내려야함;
        Vector3 local = this.transform.InverseTransformDirection(velocity);
        _speed = velocity.magnitude / _navMeshAgent.speed;
        //_speed = local.z / _navMeshAgent.speed;
        _animator.SetFloat("Speed", _speed);

        
    }
}
