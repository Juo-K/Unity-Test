using UnityEngine;

public class Move: MonoBehaviour 
{
    private void Update()
    {
        Vector3 position = this.transform.position;

        
        //keycode는 enum으로 만듬;
        //GetKey는 프레스
        //왼손좌표계 z 가 증가할 경우 안으로 들어감;

        //반환받는 거 ㅅ까지는 되는데 this.transform.position을 반환할 수 없기 때문에 position을 만들어서 받음;
        //ctrl + shift + f 카메라 위치 이동;

        if(Input.GetKey(KeyCode.W))
        {
            position.z += 10 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            position.z -= 10 * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            position.x -= 10 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            position.x += 10 * Time.deltaTime;
        }

        //if (Input.GetKey(KeyCode.D))
        //{
        //    position.x += 10 * Time.deltaTime;
        //}

        this.transform.position = position;
    }
}
