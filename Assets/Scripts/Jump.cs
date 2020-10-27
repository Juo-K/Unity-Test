using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] //직렬화
    private Rigidbody _rigidBody = null;

    [SerializeField, Range(100, 300)]
    private float _jumpForce = 200;

    [SerializeField]
    private Vector3 _position;


    private void Start()
    {
        //_rigidBody = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.AddForce(0, _jumpForce, 0);
        }
        _position = this.transform.position;
    }


}
