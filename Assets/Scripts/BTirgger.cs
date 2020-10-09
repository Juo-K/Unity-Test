using UnityEngine;

public class BTirgger : MonoBehaviour
{

    private Vector3 _position;
    private Vector3 _CPositon;
    private Vector3 _Direction;

    private Rigidbody _rigidbody = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cube")
        {
            


            //_Direction = other.transform.position - _position;
            //_CPositon = other.transform.position;

            //_rigidbody = other.GetComponent<Rigidbody>();
            //_rigidbody.useGravity = false;
        }
    }

    private void OnCollisionEnter(Collision cother)
    {
        if (cother.collider.name == "Cube")
        _Direction = cother.transform.position - _position;
        _CPositon = cother.transform.position;


        _CPositon += _Direction * 2;
        //_rigidbody = cother.rigidbody.GetComponent<Rigidbody>();
        //_rigidbody.useGravity = false;
    }

    private void Start()
    {
        _position = this.transform.position;

    }

   

   
}
