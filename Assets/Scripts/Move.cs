using UnityEngine;

public class Move : MonoBehaviour
{
    private void Update()
    {
        Vector3 position = this.transform.position;
        
        if (Input.GetKey(KeyCode.W))
            position.z += 10 * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            position.z -= 10 * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            position.x -= 10 * Time.deltaTime;
        else if (Input.GetKey(KeyCode.D))
            position.x += 10 * Time.deltaTime;

        this.transform.position = position;
    }
}
