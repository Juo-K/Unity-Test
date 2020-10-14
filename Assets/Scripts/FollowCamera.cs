using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform _player = null;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform; //업데이트 에서 실시간으로 찾아올 시
    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        this.transform.position = _player.position;
    }
}
