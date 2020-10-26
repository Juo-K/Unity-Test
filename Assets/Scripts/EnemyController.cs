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

    [SerializeField]
    private WayPointes _waypoint = null;
    private int _currentpointindex = 0;

    [SerializeField]
    private float _arrivedTime = 0.0f;
    [SerializeField, Range(1.0f, 5.0f)]
    private float _dwellTIme = 2.0f;

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
        {
            if(_waypoint == null)
            {
                _moving.Begin(_initPosition);
            }
            else
            {
                
                if(IsArrivedWaypoint() == true)
                {
                    _arrivedTime = 0.0f;
                    _currentpointindex = _waypoint.GetNextIndex(_currentpointindex);
                }

                _next = GetCurrentWayPoint();
                if (_arrivedTime > _dwellTIme)
                {
                    _moving.Begin(_next);
                }
                else
                    _arrivedTime += Time.deltaTime;
            }
            
        }
    }

    private Vector3 _next;

    private Vector3 GetCurrentWayPoint()
    {
        return _waypoint.GetWayPoint(_currentpointindex);
    }

    private bool IsArrivedWaypoint()
    {
        Vector2 point = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 wayP = new Vector2(GetCurrentWayPoint().x, GetCurrentWayPoint().z);
        return Vector2.Distance(point, wayP) < 0.25f;
    }

    private void Start()
    {
        _initPosition = this.transform.position;
        _dwellTIme = 2.0f;
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
