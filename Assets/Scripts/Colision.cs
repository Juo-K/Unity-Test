using UnityEngine;

public class Colision : MonoBehaviour
{
    //trigger
    /*
     //가로막히는 것들 (화장실 들어가는데 불켜지는 현상)
     물리연산은 없음 / 충돌검사는 함 

     충돌 된 순간 호출
     충돌 지속시 호출
     충돌 끝날시

     Enter / Stay / Exit 
    */

    //private void OnTriggerEnter(Collider other)
    //{
    //    //Collider 충돌체 컴포넌트
    //    //충돌체 둘중 하느는 regitbody가 있어야 함;
    //    string str = "Trigger Enter : " + other.name;
    //    print(str);
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    string str = "Trigger Stay : " + other.name;
    //    print(str);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    string str = "Trigger Exit : " + other.name;
    //    print(str);
    //}



    /*
     Collision
     가로막혀 있으면 못 지나감;
     */

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        //Collision 충돌 된 정보를 가지고 있음;
        //Collider 최상위

        string str = "Collision Enter :" + collision.gameObject.name;
        print(str);    
    }

    private void OnCollisionStay(Collision collision)
    {
        string str = "Collision Stay :" + collision.gameObject.name;
        print(str);
    }

    private void OnCollisionExit(Collision collision)
    {
        string str = "Collision Exit :" + collision.gameObject.name;
        print(str);
    }
}
