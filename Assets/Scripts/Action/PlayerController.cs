using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Moving _moving = null;
    private Attacking _attacking = null;
    private Rigidbody _rigidBody = null;
    private NavMeshAgent _navMeshAgent = null;
    private Animator _animator = null;
    private Sliding _sliding = null;

    private void Awake()
    {
        _animator = this.GetComponent<Animator>();
        _rigidBody = this.GetComponent<Rigidbody>();
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _moving = this.GetComponent<Moving>();
        _attacking = this.GetComponent<Attacking>();
        _sliding = this.GetComponent<Sliding>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Sliding() == true) return;
        if (Attacking() == true) return;
        if (Moving() == true) return;
    }

    private bool Attacking()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay(), 500);
            foreach (RaycastHit hit in hits)
            {
                Damage damage = hit.transform.GetComponent<Damage>();
                if (damage == null || damage.gameObject == this.gameObject)
                    continue;

                _attacking.Begin(damage);
                return true;
            }
        }
        return false;
        
    }

    private bool Sliding()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            _sliding.Begin(1000.0f);
            return true;
        }
        return false;
    }

    private bool Moving()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(GetMouseRay(), out hit, 500))
            {
                _moving.Begin(hit.point);
                return true;
            }
        }
        return false;
        
    }

    private Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition); 
    }
}
