using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform _player = null;

    [SerializeField, Range(1, 10)]
    private float _lerpSpeed = 5.0f;

    private float _speedH = 2.0f; // 수평회전속도;
    private float _speedV = 2.0f; // 수직 회전속도
    private float _yaw = 0.0f; //y축 
    private float _pitch = 0.0f; // x축 roll - z축

    private float _minFOV = 40.0f;
    private float _maxFOV = 100.0f;
    private float _zoomDistance = 60.0f;
    private float _sensityDistance = 50.0f;
    private float _damping = 5.0f;

    private Camera _camera = null;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform; //업데이트 에서 실시간으로 찾아올 시
        _camera = Camera.main;
    }

    private void Start()
    {
        _zoomDistance = _camera.fieldOfView;

    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, _player.position, _lerpSpeed * Time.deltaTime);

        _zoomDistance -= Input.GetAxis("Mouse ScrollWheel") * _sensityDistance;
        _zoomDistance = Mathf.Clamp(_zoomDistance, _minFOV, _maxFOV);
        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _zoomDistance, _damping * Time.deltaTime);



        if(Input.GetKey(KeyCode.LeftShift))
        {
            _yaw += _speedH * Input.GetAxis("Mouse X");//y축을 기준으로 회전;
            _pitch -= _speedV * Input.GetAxis("Mouse Y");//x축

            this.transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f);
            Debug.Log(Input.GetAxis("Mouse X"));
        }
    }
}
