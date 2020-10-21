using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Moving _moving = null;
    private Attacking _attacking = null;

    private GameObject _player = null;

    [SerializeField, Range(1.0f, 10.0f)]
    private float _searchRange = 5.0f;

    private Vector3 _initPosition;

    private void Awake()
    {
        _moving = this.GetComponent<Moving>();
        _attacking = this.GetComponent<Attacking>();
        _player = GameObject.Find("Racer");
    }

    private void Update()
    {
        if (InRange())
        {
            _attacking.Begin(_player.GetComponent<Damage>());
        }
        else
            _moving.Begin(_initPosition);
    }

    private void Start()
    {
        _initPosition = this.transform.position;
    }

    private bool InRange()
    {
        Vector2 targetPoint = new Vector2(_player.transform.position.x, _player.transform.position.z);
        Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.z);
        return Vector2.Distance(targetPoint, pos) < _searchRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, _searchRange);
    }
}
