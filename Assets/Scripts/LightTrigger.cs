using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    private Light[] _lights = null;

    private void Awake()
    {
        _lights = this.GetComponentsInChildren<Light>();
        print(_lights.Length.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            foreach(Light light in _lights)
            {
                light.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            foreach (Light light in _lights)
            {
                light.enabled = false;
            }
        }
    }
}
