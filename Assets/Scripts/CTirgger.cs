using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTirgger : MonoBehaviour
{

    private Vector3 _position;
    private Vector3 _CPositon;
    private Vector3 _Direction;

    private Rigidbody _rigidbody = null;

    private bool bColl = false;
    private Light[] _lights = null;
    private float collTime = 0.0f;
    private void OnCollisionEnter(Collision cother)
    {
        if (cother.collider.name == "Player")
        {
            _Direction = _position - cother.transform.position;

            
            bColl = true;
        }

        if (cother.collider.name == "Cube")
        {
            _Direction = _position - cother.transform.position;


            bColl = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        bColl = false;
    }


    private void Awake() // 문가를 찾아올 경우, 어웨이크를 하는게 좋음
    {
        _lights = this.GetComponentsInChildren<Light>(); //자식들 전부 찾아서 배열안에 넣어줌;
    }

    private void Start()
    {
        
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (bColl == true)
        {
            _rigidbody.AddForce(_Direction * 60);
        }

        _position = this.transform.position;

        if (transform.position.y <= 0.5f)
        {
            foreach (Light l in _lights)
            {
                l.enabled = true;
            }
        }
    }



}
