using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointes : MonoBehaviour
{
    [SerializeField, Range(0.1f, 1.0f)]
    private float _radius = 0.1f;

    private void OnDrawGizmos()
    {
        for (int i = 0; i< this.transform.childCount; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(GetWayPoint(i), _radius);

            int next = GetNextIndex(i);
            Gizmos.color = Color.white;

            Gizmos.DrawLine(GetWayPoint(i), GetWayPoint(next));
        }
    }

    public int GetNextIndex(int index)
    {
        return (index + 1) % this.transform.childCount;
    }

    public Vector3 GetWayPoint(int index)
    {
        return this.transform.GetChild(index).position; // 0넣을 경우 처음 친구 나옴;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
