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
    private Waypoints _waypoint = null;
    private int _currentWaypointIndex = 0;

    [SerializeField]
    private float _arrivedTime = 0.0f;
    [SerializeField, Range(1.0f, 5.0f)]
    private float _dwellTime = 2.0f;

    private Vector3 _initPosition;

    private void Awake()
    {
        _moving = this.GetComponent<Moving>();
        _attacking = this.GetComponent<Attacking>();
        _player = GameObject.Find("Player");
    }

    private void Start()
    {
        _initPosition = this.transform.position;
        _dwellTime = 2.0f;
        _next = _initPosition;
    }

    private Vector3 _next;
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
                    _currentWaypointIndex = _waypoint.GetNextIndex(_currentWaypointIndex);
                }
                _next = GetCurrentWaypoint();

                if (_arrivedTime > _dwellTime)
                {
                    _moving.Begin(_next);
                }
                else
                    _arrivedTime += Time.deltaTime;
            }
        }
    }

    private Vector3 GetCurrentWaypoint()
    {
        return _waypoint.GetWaypoint(_currentWaypointIndex);
    }

    private bool IsArrivedWaypoint()
    {
        Vector2 point = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 waypoint = new Vector2(GetCurrentWaypoint().x, GetCurrentWaypoint().z);
        return Vector2.Distance(point, waypoint) < 0.25f;
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
