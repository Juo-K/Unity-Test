using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTirgger : MonoBehaviour
{
    private Light[] _lights = null;

    private void Awake() // 문가를 찾아올 경우, 어웨이크를 하는게 좋음
    {
        _lights = this.GetComponentsInChildren<Light>(); //자식들 전부 찾아서 배열안에 넣어줌;
        print(_lights.Length.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            foreach (Light l in _lights)
            {
                l.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            foreach (Light l in _lights)
            {
                l.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
