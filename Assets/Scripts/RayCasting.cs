using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    //메인 카메라에 할당
    //메인 카메라에서 마우스로 반직선을 쐄;


    private List<int> num = new List<int>();
    private Ray _ray;
    private Transform _sphereTransform = null;
    private Vector3 _direction;
    private float _distance;
    private string _name = "None";


    private void Awake()
    {
        _sphereTransform = GameObject.Find("Sphere").transform;
        
    }

    void Update()
    {
        _direction = _sphereTransform.position - this.transform.position;
        _direction.Normalize(); //방향
        _distance = Vector3.Distance(this.transform.position, _sphereTransform.position); //거리

        _ray = new Ray(this.transform.position, _direction);//레이 구조체 생성; 위치, 방향

        RaycastHit hit;//충돌정보를 저장하는 구조체
        if (Physics.Raycast(_ray.origin, _ray.direction, out hit, _distance))//out 출력전용 매개변수
        {
            //여러개 충돌시 먼저충돌 하는 녀석 반환;
            _name = hit.collider.name;//충돌체의 이름 호출;

        }
        else
            _name = "None";
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width * 0.5f, 40), _name);//박스 크기 왼쪽상단 0,0포지션 / 넓이의 반 , 높이 40// _name값이 변할 때 호출
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_ray.origin, _ray.direction * _distance); // 방향 * 길이
    }

    
}
