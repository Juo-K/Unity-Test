using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField, Range(1, 10)]
    private float _lerpSpeed = 5.0f;

    private Transform _player = null;

    private float _speedH = 2.0f;
    private float _speedV = 2.0f;
    private float _yaw = 0.0f; //y 축
    private float _pitch = 0.0f; //x 축    roll z축

    private float _minFOV = 40.0f;
    private float _maxFOV = 100.0f;
    private float _zoomDistance = 60.0f;
    private float _sensityDistance = 50.0f;
    private float _damping = 5.0f;

    private Camera _camera = null;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
        _camera = Camera.main;
    }

    private void Start()
    {
        _zoomDistance = _camera.fieldOfView;
    }


    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, _player.transform.position, _lerpSpeed * Time.deltaTime);

        _zoomDistance -= Input.GetAxis("Mouse ScrollWheel") * _sensityDistance;
        _zoomDistance = Mathf.Clamp(_zoomDistance, _minFOV, _maxFOV);
        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _zoomDistance, _damping * Time.deltaTime);
        //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButton(1))
        {
            _yaw += _speedH * Input.GetAxis("Mouse X");
            _pitch -= _speedV * Input.GetAxis("Mouse Y");

            this.transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f);
        }
    }
}
