﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    private Animator _animator = null;
    private Vector3 _mPos;

    private void Awake()
    {
        _animator = this.GetComponent<Animator>();
    }
   
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//화면좌표계 상의 좌표를 반직선으로 바꿈; 바꾸고 싶은 값을 안에 집어넣음;
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500))//물체의 좌표까지 무조건감;
            {
                _mPos = hit.point;

            }
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Racer_Pench")  == false)
            {
                _animator.SetTrigger("Attack");
                this.transform.LookAt(_mPos);
            }

        }


        
    }

    private void OnAttack()
    {
        Debug.Log("Attack!");
    }

    private void onAttackEnd()
    {
        _animator.ResetTrigger("Attack");
    }
}
