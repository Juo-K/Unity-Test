using UnityEngine;

public class Raycasting : MonoBehaviour
{
    private Ray _ray;
    private Transform _sphereTransform = null;
    private Vector3 _direction;
    private float _distance;
    private string _name = "None";

    private void Awake()
    {
        _sphereTransform = GameObject.Find("Sphere").transform;
    }

    private void Update()
    {
        _direction = _sphereTransform.position - this.transform.position;
        _direction.Normalize();
        _distance = Vector3.Distance(this.transform.position, _sphereTransform.position);

        _ray = new Ray(this.transform.position, _direction);

        RaycastHit hit;
        if (Physics.Raycast(_ray.origin, _ray.direction, out hit, _distance))
        {
            _name = hit.collider.name;
        }
        else
            _name = "None";
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width * 0.5f, 40), _name);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_ray.origin, _ray.direction * _distance);
    }
}
