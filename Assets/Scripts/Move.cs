using UnityEngine;

public class Move: MonoBehaviour 
{
    //MonoBehaviour - 컴퍼넌트 
    //public float temp; // public private 안 달경우 internal(private -  외부에서 접근불가) DLL -동적라이브러리
    //안되면 ctrl + . 눌러

    private float temp = 10.0f;

    public float Temp { get; set; }

    public void Awake()//함수자동실행 (인스턴트화가 되었을 때 like 생성자) 이름 옆에 V표시
    {
        //Debug.Log("Awake");
    }

    // Start is called before the first frame update
    public void Start() // Update가 호출되기 직전에 호출;
    {
        //Debug.Log("Start");
        
    }

    // Update is called once per frame
    void Update() // Play를 누르고 매 프레임 마다 호출;
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(1, 0, 0);
        }
        //Debug.Log("Update");

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.localScale += new Vector3(1, 1, 1);
        }

        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 3, 0);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, -3, 0);
        }
    }

    public void FixedUpdate() // 물리연산 Delta Time을 곱하는 거랑 같은 느낌;
    {
       // Debug.Log("FixedUdapte");
    }

    public void LateUpdate() // 늦게 호출 되는 업데이트 함수; 통상적으로 카메라의 업데이트;
    {
       // Debug.Log("LateUpdate");
    }


}
//c#에서는 헤더를 쓰지않음
// using namespace - system.Collections 회색 - 쓰지않음, 검은색 사용중;
// 함수 단위로 전부 달아야함;

