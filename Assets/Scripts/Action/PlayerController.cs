using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //객체 스크립트를 가지고 있을 거입니다.

    private Moving _moving = null;
    private Attacking  _attacking = null;

    private void Awake()
    {
        _moving = this.GetComponent<Moving>();
        _attacking = this.GetComponent<Attacking>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // if()
        if (Attacking() == true) return;
        if (Moving() == true)  return;
    }

    private bool Attacking()
    {

        if (Input.GetMouseButton(0))
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay(), 500);
            foreach (RaycastHit hit in hits)
            {
                Damage damage = hit.transform.GetComponent<Damage>();
                if (damage == null)
                    continue;

                _attacking.Beging(damage);
                return true;
            }
        }
        
        return false;
    }

    private bool Moving()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(GetMouseRay(), out hit, 500))
            {
                _moving.Beging(hit.point);
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
