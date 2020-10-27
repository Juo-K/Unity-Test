using UnityEngine;

public class Collision : MonoBehaviour
{
    //trigger
    /*
         물리 연산x
         충돌 검사o

    Enter / Stay / Exit
    */

    private void OnTriggerEnter(Collider other)
    {
        string str = "Trigger Enter : " + other.name;
        print(str);
    }

    private void OnTriggerStay(Collider other)
    {
        string str = "Trigger Stay : " + other.name;
        print(str);
    }

    private void OnTriggerExit(Collider other)
    {
        string str = "Trigger Exit : " + other.name;
        print(str);
    }

    /*
     Collision 
    */

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        string str = "Collision Enter : " + collision.gameObject.name;
        print(str);
    }

    private void OnCollisionStay(UnityEngine.Collision collision)
    {
        string str = "Collision Stay : " + collision.gameObject.name;
        print(str);
    }

    private void OnCollisionExit(UnityEngine.Collision collision)
    {
        string str = "Collision Exit : " + collision.gameObject.name; ;
        print(str);
    }
}
