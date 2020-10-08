using UnityEngine;

public class Jump : MonoBehaviour
{
    //addpos rigitbody componet
    //1번째 방법
    [SerializeField] //직렬화 네트워크에서 많이쓰는 용어 (에디터한테만 열어주는 기능)
    private Rigidbody _rigidbody = null; //클래스를 선언할 때 항상 null로 초기화;

    private int count = 0;

    [SerializeField,Range(100,300)]
    private float _jumpForce = 200;

    //값을 제한하고 싶은 경우 

    //다른 컴포넌트
    //SerializeField

    [SerializeField]
    private Vector3 _position;

    // Start is called before the first frame update
    private void Start()
    {//getComponent templet 함수
     //getComponents 는 다받아옴;
        _rigidbody = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    private void Update()
    {
        if (count < 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                count++;
                _rigidbody.AddForce(0, _jumpForce, 0);
            }
        }
       
       
        _position = this.transform.position;

        if (count == 3)
        {
            if (_position.y < 0.5)
            {
                count = 0;
            }
        }


    }
}
